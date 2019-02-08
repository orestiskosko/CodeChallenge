(function () {

    let skills = [];
    let assignedSkills = [];
    const hiddenSkillsListEl = document.getElementById('hiddenSkillsList');
    const skillTagsEl = document.getElementById('skillTagsDiv');

    fetch('../../api/Skills')
        .then(res => { return res.json() })
        .then(response => {
            skills = response;
        })
        .then(() => {
            updateAssignedSkills();

            // Add new skill button click
            document.getElementById('addNewSkillBtn').addEventListener('click',
                () => {
                    const selectSkillEl = document.getElementById('newSkillOptions');
                    const selectedSkillId = selectSkillEl.value;
                    const selectedSkillName = selectSkillEl.options[selectSkillEl.selectedIndex].text;

                    if (selectedSkillId === 'new') {
                        document.getElementById('addNewSkillModal').classList.add('is-active');
                        return;
                    }

                    if (!assignedSkills.some(s => s.id === selectedSkillId)) {
                        addNewValidSkill_Main(selectedSkillId, selectedSkillName)
                    }
                });

            // Add delete events on all deletete buttons of tags
            document.querySelectorAll('.is-delete').forEach(el => {
                el.addEventListener('click', e => tagDeleteEvent(e));
            });
        })
        .catch(error => console.log(error));




    // Main logic to add a new skill tag
    function addNewValidSkill_Main(skillId, skillName) {
        createHiddenInputSkillEl(skillId);
        createSkillTag(skillName);
        updateAssignedSkills();
    };

    function tagDeleteEvent(e) {
        const skillName = e.target.parentElement.firstElementChild.innerText;

        // Remove associated tag
        e.target.parentElement.parentElement.remove();

        // Add "No skill" if no tags are present
        if (skillTagsEl.children.length === 0) {
            skillTagsEl.appendChild(document.createElement('p'));
            skillTagsEl.querySelector('p').innerText = 'No skills';
        }

        // Remove associated hidden input element
        const skillIndex = assignedSkills.findIndex(skill => skill.name === skillName);
        document.getElementById(getHiddenInputSkillId(skillIndex)).remove();

        updateAssignedSkills();
    }

    function createHiddenInputSkillEl(selectedSkillId) {
        const newInputEl = document.createElement('input');
        newInputEl.value = selectedSkillId;
        newInputEl.hidden = true;
        hiddenSkillsListEl.appendChild(newInputEl);
    }

    function createSkillTag(skillName) {

        if (skillTagsEl.children[0].nodeName === 'P') {
            skillTagsEl.children[0].remove();
        }

        const newTagHTML = `<div class="tags has-addons">
                                         <span class="tag is-info">${skillName}</span>
                                         <span class="tag is-delete"></span>
                                    </div>`;

        const newTagEl = document.createElement('div');
        newTagEl.className = 'control';
        skillTagsEl.appendChild(newTagEl);
        skillTagsEl.lastElementChild.innerHTML = newTagHTML;
        skillTagsEl.lastElementChild.querySelector('.is-delete').addEventListener('click', e => tagDeleteEvent(e));
    }

    function updateAssignedSkills() {
        assignedSkills = [];
        Array.from(hiddenSkillsListEl.children).forEach((item) => {
            assignedSkills.push({
                id: item.value,
                name: findSkillName(item.value),
            });
        });
        updateHiddenInputSkill()
    }

    function updateHiddenInputSkill() {
        const hiddenInputEls = hiddenSkillsListEl.querySelectorAll('div > input');
        for (let index = 0; index < assignedSkills.length; index++) {
            hiddenInputEls[index].id = getHiddenInputSkillId(index);
            hiddenInputEls[index].name = getHiddenInputSkillName(index);
        }
    }

    function getHiddenInputSkillId(index) {
        return `SkillIds_${index}_`;
    }

    function getHiddenInputSkillName(index) {
        return `SkillIds[${index}]`;
    }

    function findSkillName(id) {
        const skillIndex = skills.findIndex(s => {
            return s.id === id;
        });
        return skills[skillIndex].name;
    }

    //
    // Modal Logic
    //
    const newSkillModalEl = document.getElementById('addNewSkillModal');
    newSkillModalEl.querySelector('.modal-background').onclick = closeModal;
    newSkillModalEl.querySelector('.modal-close').onclick = closeModal;
    document.getElementById('addNewSkillModal_CancelBtn').onclick = closeModal;

    function closeModal() {
        newSkillModalEl.classList.toggle('is-active');
    }

    document.getElementById('addNewSkillModal_SaveBtn').onclick = () => {

        const newSkillObj = {
            name: document.getElementById('addNewSkillModal_SkillName').value,
            description: document.getElementById('addNewSkillModal_SkillDescription').value
        };

        fetch('../../api/Skills', {
            method: 'POST',
            body: JSON.stringify(newSkillObj),
            headers: {
                'Content-Type': 'application/json'
            }
        }).then(response => response.json())
            .then(response => {
                console.log('Success:', JSON.stringify(response));

                fetch('../../api/Skills')
                    .then(res => { return res.json() })
                    .then(response => {
                        skills = response;
                        const newlyAddedSkillId = skills.findIndex(s => {
                            return s.name === newSkillObj.name;
                        });
                        addNewValidSkill_Main(skills[newlyAddedSkillId].id, skills[newlyAddedSkillId].name);
                        closeModal();
                    })
                    .catch(error => console.log(error));

            })
            .catch(error => console.log(error));
    };


})();