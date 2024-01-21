using System;
using car_app_core.Domain;
using car_app_core.Dto;

namespace car_app_core.ServiceInterface
{
	public interface i_car_app_services
	{
        Task<Domain.Car> GetAsync(Guid id);
        Task<Dto.Car> Create(Dto.Car dto);
        Task<Domain.Car> Delete(Guid id);
        Task<Dto.Car> Update(Dto.Car dto);
    }
}

