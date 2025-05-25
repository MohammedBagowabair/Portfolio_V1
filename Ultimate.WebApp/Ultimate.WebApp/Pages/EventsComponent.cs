using Microsoft.AspNetCore.Components;
using Ultimate.WebApp.Interface;

namespace Ultimate.WebApp.Pages
{
    public class EventsComponent : ComponentBase
    {
        [Inject]
        IEventsService _EventsService { set; get; }



        //public async Task<List<MenuModel>> getMenu(int botId)
        //{
        //    ResponseModel<MenuModel> response = await _EventsService.GetMenu(botId);
        //    menus=response.Content;
        //    return response.Content;
        //}
    }
}
