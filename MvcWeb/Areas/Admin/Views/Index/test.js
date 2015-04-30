 
define(["text!~/Admin/index/test"], function (text)
{
    console.log(123123123)
    avalon.templateCache.test = text;
    avalon.define({
        $id: "testmt",
        username: "面条"
    });
   
    avalon.vmodels.Index.page.test = "test";
    console.log("123123123123213123")
    
});