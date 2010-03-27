<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

  <div class="content sections">

    <div class="section">

      <h3>Variables</h3>
      <p>
        Variables allow you to specify widely used values in a single place, and then re-use
        them throughout the style sheet, making global changes as easy as changing one line
        of code.
      </p>
      <div class="code_example rounded_corners">
        <pre class="less_example">
<span>@brand_color</span>: #4D926F;
 
#header {
  color: <span>@brand_color</span>;
}
 
h2 {
  color: <span>@brand_color</span>;
}
</pre>
      </div>
    
      <h3>Operations</h3>
      <p>
        Are some elements in your style sheet proportional to other elements? Operations
        let you add, subtract, divide and multiply property values and colors, giving you
        the power to do create complex relationships between properties.
      </p>
      <div class="code_example rounded_corners">
        <pre class="less_example">
@the-border: 1px;
@base-color: #111;
 
#header {
  color: <span>@base-color * 3</span>;
  border-left: @the-border;
  border-right: <span>@the-border * 2</span>;
}
 
#footer { 
  color: <span>(@base-color + #111) * 1.5</span>; 
}
</pre>
      </div>
    </div>
      
    <div class="section rounded_corners">
      <h3>Mixins</h3>

      <p>
        Mixins allow you to embed all the properties of a class into another class by simply
        including the class name as one of its properties. It's just like variables, but
        for whole classes.
      </p>
      <div class="code_example rounded_corners">
        <pre class="less_example">
.rounded_corners(@radius: 5px) {
  -moz-border-radius: @radius;
  -webkit-border-radius: @radius;
  border-radius: @radius;
}
 
#header {
  <span>.rounded_corners</span>;
}
 
#footer {
  <span>.rounded_corners(10px)</span>;
}
</pre>
      </div>

      <h3>Nested Rules</h3>
      <p>
        Rather than constructing long selector names to specify inheritance, in Less you
        can simply nest selectors inside other selectors. This makes inheritance clear and
        style sheets shorter.
      </p>
      <div class="code_example rounded_corners">
        <pre class="less_example">
#header {
  color: red;
  <span>a { 
       font-weight: bold; 
       text-decoration: none; 
    }</span> 

}
</pre>
      </div>
    </div>

    <div class="section">
      <div  id="getting-started">
        <h3 class="option">1. Download the latest source</h3>
        <p>You can find the latest source code for dotless at GitHub and build the project</p>
        <hr />

        <h3 class="option">2. Include our reference to your web project</h3>
        <p><img src="../../Content/Images/references.jpg" alt="Add a few reference" /></p>   
        <hr />
        <h3 class="option">3. Add a new HttpHandler to your Web.Config</h3>
        <p>Lets make the dotless processor handle our .LESS files. </p>
        <p>Add this entry to the HttpHandlers section of your Web.Config:</p>
        
        <div class="code_example">
          <pre class="less_example">
&lt;add type="
dotless.Core.LessCssHttpHandler
,dotless.Core" validate="false" 
path="*.LESS" verb="*"/&gt;
</pre>
        </div>
        
        <hr />
        <h3 class="option">4. Add a few configuration sections (optional)</h3>
        <p>First add our config handler in the "configSections" node of your web.config</p> 
        <div class="code_example">
          <pre class="less_example">
&lt;section name="dotless" 
type="dotless.Core.configuration.
DotlessConfigurationSectionHandler
,dotless.Core" /&gt;
</pre>
        </div>
        <p>Now you can configure if you enable Caching and minifying or the Css output</p> 
        <div class="code_example">
          <pre class="less_example">
&lt;dotless 
minifyCss="false" 
cacheEnabled="true" /&gt;
</pre>
        </div>

        <hr />
        <h3 class="option">5. Get started</h3>
        <p>Reference your LESS files the same way as you would any other CSS file, just ensure that you use the .LESS extention.</p>
      </div>
      
      <div style="float:right;">
        <a href="http://www.engineroomapps.com" title="Thanks to - Engine Room Apps">
          <img src="<%= Url.Content("~/Content/Images/engineroom_logo.jpg") %>"  alt="Engine Room Apps" />
        </a>
      </div>
    </div>
    <span class="clearer"></span>

  </div>


</asp:Content>
