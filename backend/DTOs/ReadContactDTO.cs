namespace API.DTOs
{
    public class ReadContactDTO
    {
        //Create a read contact DTO class with the following properties id of type GUID, firstname, lastname, physical address and delivery address
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhysicalAddress { get; set; }
        public string DeliveryAddress { get; set; }
    }
}
