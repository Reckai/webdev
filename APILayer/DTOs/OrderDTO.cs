namespace APILayer.DTOs;

public class OrderDTO
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public int UserId { get; set; }
    public decimal TotalAmount { get; set; }
    public ICollection<OrderItemDTO> OrderItems { get; set; } = new List<OrderItemDTO>();
}