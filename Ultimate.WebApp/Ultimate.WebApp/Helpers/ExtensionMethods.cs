using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using System.Globalization;

namespace Ultimate.WebApp.Helpers
{
    public class ExtensionMethods
    {
    }

    public static class WebAssemblyHostExtension
    {
        public async static Task SetDefaultCulture(this WebAssemblyHost host)
        {
            CultureInfo culture = new CultureInfo("ar");

            try
            {
                var jsInterop = host.Services.GetRequiredService<IJSRuntime>();
                var result = await jsInterop.InvokeAsync<string>("blazorCulture.get");
                if (result != null)
                    culture = new CultureInfo(result);
                else
                    culture = new CultureInfo("ar");
            }
            catch
            {
                culture = new CultureInfo("ar");
            }
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
        }
    }
}
