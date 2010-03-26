<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div id="hd1">
    <div class="content">
      <ul>
        <li><a href="http://github.com/dotless/dotless" target="_blank" title="See Source Code">See Source Code</a></li>
        <li><a href="http://clicktotweet.com/d45UW" target="_blank" title="Tweet about us">Tweet about .Less</a></li>
        <li><a href="http://groups.google.com/group/dotless" target="_blank" title="Discuss DotLess With Us">Discuss .Less</a></li>
      </ul>
      <img src="<%= Url.Content("~/Content/Images/logo.jpg") %>" alt="dotless - a LESS css port for .NET" id="logo"  /> 
      <a href="#stay" title="Dotless - is in beta so please bear us through the issues">
        <img src="<%= Url.Content("~/Content/Images/beta.png") %>" alt="dotless - is in beta so bear us" id="beta"  />
      </a> 
    </div>
  </div>
  <div id="hd2">
    <div class="content">
      <div class="left">
        <h1>Write regular CSS with your .NET apps, <br />
            then add a few variables, mixins and nested rules. </h1>  
        <p>
          .less (pronounced dot-less)  is a .NET port of the funky <a href="http://lesscss.org/" title="LESS css"  target="_blank">ruby LESS libary</a><br />
          Lovingly ported by 
            <a href="http://enginechris.wordpress.com/" title="Chris Owen"  target="_blank">Christopher Owen</a>,  
            <a href="http://blog.smoothfriction.nl/" title="Erik van Brakel"  target="_blank"> Erik van Brakel</a> and
            <a href="http://www.tigraine.at/" title="Daniel Hoelbling"  target="_blank">Daniel Hoelbling</a>
        </p>
      </div> 
      <div class="right">
        <a href="http://www.dotlesscss.com:8081/viewLog.html?buildId=lastPinned&buildTypeId=bt3&tab=artifacts&guest=1" title="Get dotless" target="_blank">
          <img src="<%= Url.Content("~/Content/Images/download_button.png") %>" style="border:0;" alt="download"  />
        </a> 
      </div>
    </div>
  </div>
  <div id="bd1">
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
.rounded_corners {
  -moz-border-radius: 8px;
  -webkit-border-radius: 8px;
  border-radius: 8px;
}
 
#header {
  <span>.rounded_corners</span>;
}
 
#footer {
  <span>.rounded_corners</span>;
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
  </div>
  <div id="ft1">
    <div class="content">
    </div>
  </div>

  <script type="text/javascript">
    var gaJsHost = (("https:" == document.location.protocol) ? "https://ssl." : "http://www.");
    document.write(unescape("%3Cscript src='" + gaJsHost + "google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));
  </script>
  <script type="text/javascript">
    try {
        var pageTracker = _gat._getTracker("UA-11138592-1");
        pageTracker._trackPageview();
      } catch (err) { }
  </script>


</asp:Content>
