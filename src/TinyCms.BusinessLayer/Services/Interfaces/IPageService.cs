using TinyCms.Shared.Models;

namespace TinyCms.BusinessLayer.Services.Interfaces;

public interface IPageService
{
    Task<ContentPage> GetAsync(string url);
}