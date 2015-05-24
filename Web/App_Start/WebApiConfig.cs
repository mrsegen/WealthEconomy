using Microsoft.Owin.Security.OAuth;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Filters;
using System.Web.OData;
using System.Web.OData.Batch;
using System.Web.OData.Extensions;
using Web.ExceptionHandling;

namespace Web
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // OData

            // Query support
            //config.EnableQuerySupport();
            var odataFilter = new EnableQueryAttribute() { MaxExpansionDepth = 4 };
            config.AddODataQueryFilter(odataFilter);

            //config.Routes.MapODataRoute(
            //    routeName: "ODataRoute",
            //    routePrefix: "odata",
            //    model: edm,
            //    batchHandler: new BatchHandler(GlobalConfiguration.DefaultServer));

            // Routes
            var edmOld = Facade.DbUtility.GetWealthEconomyContextEdm();

            var builder = new System.Web.OData.Builder.ODataConventionModelBuilder();
            //builder.EntitySet<BusinessObjects.ResourcePool>("ResourcePool");
            //builder.EntitySet<BusinessObjects.UserResourcePool>("UserResourcePool");
            builder.EntitySet<Test>("Test");
            builder.Namespace = "Web";
            //var edm = builder.GetEdmModel();
            Microsoft.OData.Edm.IEdmModel edm2;

            using (var stream = new System.IO.MemoryStream())
            {
                var errors = new System.Collections.Generic.List<Microsoft.OData.Edm.Validation.EdmError>();
                var errors2 = errors.AsEnumerable();
                using (var writer = System.Xml.XmlWriter.Create(stream))
                {
                    Microsoft.OData.Edm.Csdl.EdmxWriter.TryWriteEdmx(edmOld, writer, Microsoft.OData.Edm.Csdl.EdmxTarget.EntityFramework, out errors2);
                    // System.Data.Entity.Infrastructure.EdmxWriter.WriteEdmx(edm, writer);
                }

                stream.Position = 0;

                //// Add readonly properties
                var edmx = System.Xml.Linq.XDocument.Load(stream);
                //AddReadonlyProperty(edmx, "ResourcePool", "OtherUsersResourcePoolRateTotal", "Decimal", true);
                ////AddReadonlyProperty(edmx, "ResourcePool", "OtherUsersResourcePoolRateAverage", "Decimal", true);
                //AddReadonlyProperty(edmx, "ResourcePool", "OtherUsersResourcePoolRateCount", "Int32", false);
                //AddReadonlyProperty(edmx, "ElementFieldIndex", "OtherUsersIndexRatingTotal", "Decimal", true);
                ////AddReadonlyProperty(edmx, "ElementFieldIndex", "OtherUsersIndexRatingAverage", "Decimal", true);
                //AddReadonlyProperty(edmx, "ElementFieldIndex", "OtherUsersIndexRatingCount", "Int32", false);
                //AddReadonlyProperty(edmx, "ElementCell", "OtherUsersRatingTotal", "Decimal", true);
                ////AddReadonlyProperty(edmx, "ElementCell", "OtherUsersRatingAverage", "Decimal", true);
                //AddReadonlyProperty(edmx, "ElementCell", "OtherUsersRatingCount", "Int32", false);

                /* UNCOMMENT THIS IN CASE YOU WANT TO SAVE AND INSPECT THE EDMX FILE */
                stream.Position = 0;
                var edmxDocument = new System.Xml.XmlDocument();
                edmxDocument.Load(stream);
                //edmxDocument.Save(@"D:\v4.xml");

                using (var reader = edmx.CreateReader())
                {
                    // edm2 = Microsoft.OData.Edm.Csdl.EdmxReader.Parse(reader);
                    edm2 = Microsoft.OData.Edm.Csdl.EdmxReader.Parse(reader);
                }

                // Old part
                //using (var reader = XmlReader.Create(stream))
                //{
                //    return EdmxReader.Parse(reader);
                //}
            }

            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: "odata",
                model: edmOld,
                batchHandler: new BatchHandler(GlobalConfiguration.DefaultServer));

            // Exception logger
            config.Services.Add(typeof(IExceptionLogger), new ElmahExceptionLogger());

            // Exception handler
            config.Services.Replace(typeof(IExceptionHandler), new GenericExceptionHandler());
        }
    }

    public class BatchHandler : DefaultODataBatchHandler
    {
        public BatchHandler(HttpServer httpServer)
            : base(httpServer)
        { }

        public override System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage> CreateResponseMessageAsync(System.Collections.Generic.IEnumerable<ODataBatchResponseItem> responses, System.Net.Http.HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            return base.CreateResponseMessageAsync(responses, request, cancellationToken);
        }

        public override System.Threading.Tasks.Task<System.Collections.Generic.IList<ODataBatchResponseItem>> ExecuteRequestMessagesAsync(System.Collections.Generic.IEnumerable<ODataBatchRequestItem> requests, System.Threading.CancellationToken cancellationToken)
        {
            return base.ExecuteRequestMessagesAsync(requests, cancellationToken);
        }

        public override System.Threading.Tasks.Task<System.Collections.Generic.IList<ODataBatchRequestItem>> ParseBatchRequestsAsync(System.Net.Http.HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            return base.ParseBatchRequestsAsync(request, cancellationToken);
        }

        public override System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage> ProcessBatchAsync(System.Net.Http.HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            return base.ProcessBatchAsync(request, cancellationToken);
        }

        public override void ValidateRequest(System.Net.Http.HttpRequestMessage request)
        {
            base.ValidateRequest(request);
        }

        public override System.Uri GetBaseUri(System.Net.Http.HttpRequestMessage request)
        {
            return base.GetBaseUri(request);
        }
    }
}
