using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace UserManagement.Helpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement(Attributes = "asp-active-route")]
    public class ActiveRouteTagHelper : TagHelper
    {
        [ViewContext]
        public ViewContext ViewContext { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //Get the current requested "Controller" and "Action" using "ViewContext"
            string currentRequestedController = ViewContext.RouteData.Values["Controller"].ToString();
            string currentRequestedAction = ViewContext.RouteData.Values["Action"].ToString();

            //Get the (Controller and Action) attributes name by using "context" as follows:
            string tagController = context.AllAttributes.Where(attr => attr.Name == "asp-controller").FirstOrDefault().Value.ToString();
            string tagAction = context.AllAttributes.Where(attr => attr.Name == "asp-action").FirstOrDefault().Value.ToString();

            if (currentRequestedController == tagController && currentRequestedAction == tagAction)
            {
                //Get the existing Css class attribute using below code:
                string existingCss = context.AllAttributes.Where(attr => attr.Name == "class").FirstOrDefault().Value.ToString();
                //Get the new Css class and combine with the existing Css using below code:
                string newCss = existingCss + " " + context.AllAttributes.Where(attr => attr.Name == "asp-active-route").FirstOrDefault().Value.ToString();
                //Assign the new Css using below code:
                output.Attributes.SetAttribute("class", newCss);
            }
        }
    }
}
