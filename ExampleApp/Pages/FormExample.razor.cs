using System.ComponentModel.DataAnnotations;

namespace ExampleApp.Pages
{
    public partial class FormExample
    {
        public ExampleModel FormModelExample { get; set; } = new ExampleModel();
        
        public class ExampleModel
        {
            [Required]
            [StringLength(10, ErrorMessage = "Name is too long.")]
            public string Name { get; set; }
        }

        private void HandleValidSubmit()
        {
        }
    }
}