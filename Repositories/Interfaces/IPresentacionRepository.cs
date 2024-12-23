﻿using FarmaciaApi.DTOs.Views;
using FarmaciaApi.Models;

namespace FarmaciaApi.Repositories.Interfaces
{
    public interface IPresentacionRepository
    {
        Task<IEnumerable<Presentacion>> GetPresentaciones();
        Task<IEnumerable<PresentacionViewDTO>> GetPresentacionesView();
        Task<Presentacion?> GetByIdAsync(int id);
        Task<PresentacionViewDTO?> GetByIdViewAsync(int id);
        Task<Presentacion> CreatePresentacion(Presentacion presentacion);
        Task UpdatePresentacion(Presentacion presentacion);
        Task DeletePresentacion(Presentacion presentacion);
    }
}
