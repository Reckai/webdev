namespace APILayer.DTOs;

public class UserDTO
{
    public int Id { get; set; }
    public string Login { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public ICollection<OrderDTO> Orders { get; set; } = new List<OrderDTO>();
}