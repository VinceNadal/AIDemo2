using API.Data;
using API.DTOs;
using API.Models;
using AutoMapper;

namespace API.Services
{
    public class JsonFileService
    {
        // Use JsonFileRepository to read and write data
        private readonly JsonFileRepository _repository;
        private readonly IMapper _mapper;
        public JsonFileService(JsonFileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // Create a method to get all contacts from JsonFileRepository and return a list of ReadContactDTO and use AutoMapper
        public List<ReadContactDTO> GetContacts()
        {
            var readContactDtos = _mapper.Map<List<ReadContactDTO>>(_repository.GetContacts());
            return readContactDtos;
        }

        // Create a method to get a single contact given id from JsonFileRepository and return a ReadContactDTO and use AutoMapper
        public ReadContactDTO GetContact(Guid id)
        {
            var readContactDto = _mapper.Map<ReadContactDTO>(_repository.GetContact(id));
            return readContactDto;
        }

        // Create a method to add a new contact to JsonFileRepository and use AutoMapper
        public ReadContactDTO AddContact(CreateContactDTO createContactDto)
        {
            var contact = _mapper.Map<Contact>(createContactDto);
            _repository.AddContact(contact);
            _repository.SaveChanges();
            return _mapper.Map<ReadContactDTO>(contact);
        }

        // Create a method to update a contact in JsonFileRepository and use AutoMapper
        public ReadContactDTO UpdateContact(UpdateContactDTO updateContactDto)
        {
            var contact = _repository.GetContact(updateContactDto.Id);
            if (contact != null)
            {
                _mapper.Map(updateContactDto, contact);
                _repository.UpdateContact(contact);
                _repository.SaveChanges();
                return _mapper.Map<ReadContactDTO>(contact);
            }
            return null;
        }

        // Create a method to delete a contact in JsonFileRepository
        public void DeleteContact(Guid id)
        {
            var contact = _repository.GetContact(id);
            if (contact != null)
            {
                _repository.DeleteContact(id);
                _repository.SaveChanges();
            }
        }
    }
}
