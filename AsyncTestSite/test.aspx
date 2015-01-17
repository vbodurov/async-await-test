<%@ Page Language="C#" AutoEventWireup="false" %>
<script runat="server">

    protected override void OnInit(EventArgs e)
    {
        // simulate slow work
        System.Threading.Thread.Sleep(200);
        Response.ContentType = "application/json";
        Response.Write("{" +
                       "\"ID\":123," +
                       "\"Name\":\"John\"" +
                       "}");
    }
</script>

