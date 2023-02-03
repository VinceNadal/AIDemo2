namespace API.DTOs
{
    public class CreateContactDTO
    {
        //Create a create contact DTO class with the following properties firstname, lastname, physical address and delivery address
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhysicalAddress { get; set; }
        public string DeliveryAddress { get; set; }

    }
}
