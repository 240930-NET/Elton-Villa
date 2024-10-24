namespace P1.API.Model.DTO;

public class NewCategoryDTO{
    public required string Title {get; set; } = "";
    public required List<string> Options {get; set; } = [];
}