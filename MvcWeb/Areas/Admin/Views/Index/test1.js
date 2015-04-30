 
define(["text!~/Admin/index/test1"], function (text)
{
    console.log(123123123)
    avalon.templateCache.test1 = text;
    avalon.define({
        $id: "testmt1",
        username: "面条1"
    });
    var aaaa = {};
    aaaa[0] = "zzz";

    aaaa["aaa"] = "呵呵";
    aaaa["bb"] = "哈哈";
  //  aaaa.put("aaaa", "cccc")
    avalon.log(aaaa);



    avalon.vmodels.Index.page["test1"] = "test1";
    console.log("123123123123213123")
    
});