namespace APILayer.DTOs;

public class CreateOrderDTO
{
    public int UserId { get; set; }
    public ICollection<CreateOrderItemDTO> OrderItems { get; set; } = new List<CreateOrderItemDTO>();
}