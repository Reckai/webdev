namespace APILayer.DTOs;

public class CreateUserDTO
{
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}