﻿require.config({
    baseUrl: "/",
    paths: {
        "layout": "/Scripts/avalon/layout/avalon.layout",
        "scrollbar": "/Scripts/avalon/scrollbar/avalon.scrollbar",
        "tree.menu": "/Scripts/avalon/tree/avalon.tree.menu",
        "tab": "/Scripts/avalon/tab/avalon.tab",




        "testui": "/Scripts/avalon/testui/avalon.testui",
        "panel": "/Scripts/avalon/panel/avalon.panel"
    }
   , urlArgs: "bust=" + (new Date()).getTime()
});
require(["layout", "testui", "css!./Css/Global.css", "css!./Css/menu-tree.css",
    "panel", "scrollbar", "tree.menu", "tab"], function ()
{
    
    var layoutVMOptions={
        northRegion: {
            size: 150,
            resizable: false,
            regionClass: "north", 
            htmltxt: ' north北区配置尺寸为{{northRegion.size}}。<input type="button" ms-click="TestClick" />'
        },
        southRegion: {
            size: 25,
            resizable: false
            //  ,regionClass: "some-css-class0 some-css-class1"
        },
        westRegion: {
            size: 201
            //,
            //resizable: true
        },
        //eastRegion: {
        //    size: 120,
        //    resizable: true
        //},
           
        centreRegion: {
            // regionClass: "addtional-class-for-centre"
        },
        stretchMax: true,
        resizerSize: 4,
        regionBorderWidth: 0

    };

    var child = []

    var zNodes = [
        { id: 1, pid: 0, name: "时间管理呵呵呵呵的发",  "iconSkin": "flight" },
        { id: 11, pid: 1, name: "国内" },
        { id: 111, pid: 11, name: "北京", url: "Index/test" ,guid:"test"},
        { id: 112, pid: 11, name: "上海", url: "Index/test1" ,guid:"test1"},
        { id: 113, pid: 11, name: "广州", url: "http://localhost:8033/Home#", guid: "hehe" },
        { id: 114, pid: 11, name: "时间管理呵呵呵呵的发" },
          { id: 111, pid: 11, name: "北京", url: "Index/test3", guid: "test3" },
        { id: 112, pid: 11, name: "上海" },
        { id: 113, pid: 11, name: "广州" },
        { id: 114, pid: 11, name: "深圳" },
          { id: 111, pid: 11, name: "北京" },
        { id: 112, pid: 11, name: "上海" },
        { id: 113, pid: 11, name: "广州" },
        { id: 114, pid: 11, name: "深圳" },
          { id: 111, pid: 11, name: "北京" },
        { id: 112, pid: 11, name: "上海" },
        { id: 113, pid: 11, name: "广州" },
        { id: 114, pid: 11, name: "深圳" },
          { id: 111, pid: 11, name: "北京" },
        { id: 112, pid: 11, name: "上海" },
        { id: 113, pid: 11, name: "广州" },
        { id: 114, pid: 11, name: "深圳" },
          { id: 111, pid: 11, name: "北京" },
        { id: 112, pid: 11, name: "上海" },
        { id: 113, pid: 11, name: "广州" },
        { id: 114, pid: 11, name: "深圳" },
          { id: 111, pid: 11, name: "北京" },
        { id: 112, pid: 11, name: "上海" },
        { id: 113, pid: 11, name: "广州" },
        { id: 114, pid: 11, name: "深圳" },
          { id: 111, pid: 11, name: "北京" },
        { id: 112, pid: 11, name: "上海" },
        { id: 113, pid: 11, name: "广州" },
        { id: 114, pid: 11, name: "深圳" },
          { id: 111, pid: 11, name: "北京" },
        { id: 112, pid: 11, name: "上海" },
        { id: 113, pid: 11, name: "广州" },
        { id: 114, pid: 11, name: "深圳" },
        { id: 12, pid: 1, name: "国际" },
        { id: 121, pid: 12, name: "美国" },
        { id: 122, pid: 12, name: "德国" },
        { id: 123, pid: 12, name: "日本" },
        { id: 124, pid: 12, name: "英国" },
        { id: 2, pid: 0, name: "酒店", "iconSkin": "hotel" ,open: true    },
        { id: 21, pid: 2, name: "五星级酒店" },
        { id: 211, pid: 21, name: "逗比酒店" },
        { id: 212, pid: 21, name: "坑爹酒店" },
        { id: 22, pid: 2, name: "四星级以下" },
        { id: 221, pid: 22, name: "E边酒店" },
        { id: 222, pid: 22, name: "W边酒店" },
        { id: 223, pid: 22, name: "N边酒店" },
        { id: 224, pid: 22, name: "S边酒店" }
    ];

     var tree = avalon.mix(true, {}, avalon.treeMenu, {
        children: zNodes,
        data: {
            simpleData: {
                enable: true,
                pIdKey: "pid"
            }
        },
        toggleMenuTreeBack: function ()
        { 
            avalon.vmodels.layoutVM1.westRegion.size = avalon.vmodels.tree2.widgetElement.clientWidth;
            avalon.vmodels.layoutVM1.updateLayoutSize(avalon.vmodels.layoutVM1);
        },
        callback: {
            
            onClick: function (data)
            {
                if (data.leaf.url != "" && data.leaf.url.indexOf("http:")>-1&&!avalon.vmodels.tabVM.selecttabname(data.leaf.guid))
                {

                    avalon.vmodels.tabVM.add({
                        title: data.leaf.name,
                        name: data.leaf.guid,
                        content: '<iframe frameborder="0" style="width:99%;height:666;" src="' + data.leaf.url + '" scrolling="yes">'
                    });
                    var index = avalon.vmodels.tabVM.tabs.length - 1; 
                    avalon.vmodels.tabVM.active = index;


                }else if (data.leaf.url != "" && data.leaf.guid != "" && !avalon.vmodels.tabVM.selecttabname(data.leaf.guid))
                {
                  
                        require(["/Areas/Admin/Views/" + data.leaf.url], function ()
                        { 
                            avalon.vmodels.tabVM.add({
                                title: data.leaf.name,
                                name: data.leaf.guid,
                                content: '<div  ms-include-src="page.' + data.leaf.guid + '">模板加载未成功</div>'
                            });
                            var index = avalon.vmodels.tabVM.tabs.length - 1;
                          
                            avalon.vmodels.tabVM.active = index;
                            //avalon.scan();
                        });
                       
                }
             
               
                console.log(avalon.vmodels)
            } 
        }


    })

    var scrollbar = {
        show: "always",
        showBarHeader: true,
        size: "small",
        toggle:true
    };

    var tabs = [{ title: "测试非的故事的放速度 df1", name: "tab1"},
        { title: "测试2", name: "tab2"  },
         { title: "测试3", name: "tab3"  }
    ];

    var tabcs = [{   content: "<b>测试1</b>" },
        { content: '测试2<div   >模板加载未成功</div>' },
         {  content: "测试3" }
    ];


   //var peaple = {
   //     title: "人类"
   //       , content: "我是来搞笑的"
   // }
    var tabopts = {
        onActivate: function (e)
        {
           // avalon.vmodels.tabVM.add(peaple);
        }, active: 2
        , event: "click"
        , activeDelay: 250
        , forceCut: true
        , cutEnd: ""
        , tabs: tabs
        , tabpanels: tabcs
    };

   // avalon.templateCache.empty = "&nbsp;123";

    var vm= avalon.define({
        $id: "Index",
        clientHeight: document.documentElement.clientHeight,
        clientWidth: document.documentElement.clientWidth, 
        $layoutVMOptions: layoutVMOptions, 
        $scrollbar: scrollbar, 
        scrollbarupdate: function () { avalon.vmodels.scrollbarVM.update(); }, 
        $treeopts: tree,
        $tabopts:tabopts,
        page: [],
        TestClick:function(){
            //vm.$layoutVMOptions.southRegion.size -= 1;
      
            avalon.log(avalon.vmodels);
            
        },
        $panelopts:{aaa:"呵呵"}
    });
         

    avalon.scan();


}); 