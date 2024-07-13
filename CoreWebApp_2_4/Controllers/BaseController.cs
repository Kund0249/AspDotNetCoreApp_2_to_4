using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CoreWebApp_2_4.Controllers
{
    public enum NotificationType
    {
        success,
        warning,
        info,
        error
    }
    public class BaseController : Controller
    {
        public void ShowNotification(string Title, string Message, NotificationType type)
        {
            string MessageType = "";

            switch (type)
            {
                case NotificationType.success:
                    MessageType = "success";
                    break;
                case NotificationType.warning:
                    MessageType = "warning";
                    break;
                case NotificationType.info:
                    MessageType = "info";
                    break;
                case NotificationType.error:
                    MessageType = "error";
                    break;
                default:
                    MessageType = "error";
                    break;
            };

            var notificationMessage = new
            {
                Title = Title,
                Message = Message,
                MessageType = MessageType
            };
            TempData["Message"] = JsonSerializer.Serialize(notificationMessage);
        }
    }
}
