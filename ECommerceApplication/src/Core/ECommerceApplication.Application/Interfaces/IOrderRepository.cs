using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApplication.Domain;

namespace ECommerceApplication.Application.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Orders>> GetOrdersAsync();


        Task<Orders> GetOrderByIdAsync(int id);


        
        Task<Orders> AddOrderAsync(string userId,int quantity,int productId);
        //Task<Orders> AddOrderAsync(string userId,Orders order,int productId);


        Task<Orders> UpdateOrderAsync(int id,Orders order);


        Task<bool> DeleteOrderAsync(int id);
    }
}
