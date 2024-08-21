using System.ComponentModel.DataAnnotations;

namespace FahasaStoreApp.Models
{
    public class ErrorViewModel
    {
        [Required(ErrorMessage = "Nhap vao day")]
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
