namespace Demo.Presentation.ViewModels.Department
{
    //Make that class to make it the model is binding in edit view and is the same view used in edit action which send to edit view
    public class DepartementEditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty!;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateOnly DateOfCreation { get; set; }
    }
}
