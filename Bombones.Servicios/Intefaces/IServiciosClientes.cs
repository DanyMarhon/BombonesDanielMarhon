using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Servicios.Intefaces
{
    public interface IServiciosClientes
    {
        void Borrar(int clienteId);
        bool EstaRelacionado(int clienteId);
        bool Existe(Cliente cliente);
        List<ClienteListDto> GetLista();
        void Guardar(Cliente cliente);
    }
}
