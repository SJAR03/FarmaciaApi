﻿using FarmaciaApi.DTOs.Create;
using FarmaciaApi.DTOs.Update;
using FarmaciaApi.DTOs.Views;
using FarmaciaApi.Models;

namespace FarmaciaApi.Services.Interfaces
{
    public interface IPresentacionService
    {
        Task<IEnumerable<PresentacionViewDTO>> GetPresentacionesView();
        Task<IEnumerable<Presentacion>> GetPresentaciones();
        Task<Presentacion?> GetByIdAsync(int id);
        Task<PresentacionViewDTO?> GetByIdViewAsync(int id);
        Task<Presentacion> CreatePresentacion(PresentacionCreateDTO dto);
        Task UpdatePresentacion(int id, PresentacionUpdateDTO dto);
        Task DeletePresentacion(int id);
    }
}
