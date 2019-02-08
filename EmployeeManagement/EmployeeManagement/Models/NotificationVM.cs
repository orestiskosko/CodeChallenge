using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class NotificationVM
    {
        public NotificationVM()
        {
            Message = string.Empty;
            IsInfo();
        }


        public NotificationVM(string message, NotificationLevel level)
        {
            Message = message;
            switch (level)
            {
                case NotificationLevel.Info:
                    IsInfo();
                    break;
                case NotificationLevel.Warning:
                    IsWarning();
                    break;
                case NotificationLevel.Critical:
                    IsCritical();
                    break;
                default:
                    break;
            }
        }

        public string Message { get; set; }
        public string StatusClass { get; set; }

        private void IsInfo() => StatusClass = "is-success";
        private void IsWarning() => StatusClass = "is-warning";
        private void IsCritical() => StatusClass = "is-danger";

    }

    public enum NotificationLevel
    {
        Info,
        Warning,
        Critical
    }
}
