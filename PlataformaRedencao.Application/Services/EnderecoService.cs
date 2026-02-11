using AutoMapper;
using PlataformaRedencao.Application.DTOs;
using PlataformaRedencao.Application.Interfaces;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Interfaces;

namespace PlataformaRedencao.Application.Services
{
    /// <summary>
    /// Implementação do serviço para operações relacionadas a endereços.
    /// </summary>
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="AddressService"/>.
        /// </summary>
        public AddressService(IAddressRepository enderecoRepository, IMapper mapper)
        {
            _addressRepository = enderecoRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtém todos os endereços.
        /// </summary>
        public async Task<IReadOnlyCollection<AddressDTO>> GetAddressAsync()
        {
            var itens = await _addressRepository.GetAllAsync();
            return _mapper.Map<IReadOnlyCollection<AddressDTO>>(itens);
        }

        /// <summary>
        /// Obtém um endereço pelo identificador.
        /// </summary>
        public async Task<AddressDTO> GetById(int? id)
        {
            var item = await _addressRepository.GetByIdAsync(id);
            return _mapper.Map<AddressDTO>(item);
        }

        /// <summary>
        /// Adiciona um novo endereço.
        /// </summary>
        public async Task Add(AddressDTO AddressDTO)
        {
            var entidade = _mapper.Map<Address>(AddressDTO);
            await _addressRepository.AddAsync(entidade);
        }

        /// <summary>
        /// Atualiza um endereço existente.
        /// </summary>
        public async Task Update(AddressDTO AddressDTO)
        {
            var entidade = _mapper.Map<Address>(AddressDTO);
            await _addressRepository.UpdateAsync(entidade);
        }

        /// <summary>
        /// Remove um endereço pelo identificador.
        /// </summary>
        public async Task Remove(int? id)
        {
            var entidade = await _addressRepository.GetByIdAsync(id);
            if (entidade is null)
                return;

            await _addressRepository.DeleteAsync(entidade);
        }
    }
}