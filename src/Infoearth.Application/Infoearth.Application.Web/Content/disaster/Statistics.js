$(function () {
    var current_index = 0;//当前选中项的索引  如果是父节点最大的索引是14 如果是子节点最大的索引是待定
    var divname = "";//选中的当前id
    var markindex = 0;
    $(document).ready(function () {
        $("#cancle").hide();
        $("#yes").hide();
        //树状结构初始化 灾害类型
        $("#zaihaiallcount")[0].style.display = "none"; //灾害总数
        $("#yinhuandiancount")[0].style.display = "none"; //隐患点
        $("#huaPo")[0].style.display = "none"; //滑坡
        $("#bengTa")[0].style.display = "none"; //崩塌
        $("#taXian")[0].style.display = "none"; //塌陷
        $("#nishiLiu")[0].style.display = "none"; //泥石流
        $("#dimcj")[0].style.display = "none"; //地面沉降
        $("#dilieFeng")[0].style.display = "none"; //地裂缝
        $("#xiePo")[0].style.display = "none"; //斜坡
        $("#wendingcd")[0].style.display = "none"; //稳定程度
        $("#bianhuaqs")[0].style.display = "none"; //今后变化趋势
        $("#zaocweih")[0].style.display = "none"; //造成危害
        $("#qianzwx")[0].style.display = "none"; //潜在威胁
        //$("#jiancejy")[0].style.display = "none"; //监测建议
        //$("#fangzhijy")[0].style.display = "none"; //防治建议

        //稳定及变形情况 目前稳定程度
        $("#wendingcd")[0].style.display = "none";
        $("#wendwendxh")[0].style.display = "none"; //稳定性好
        $("#wendwendxjc")[0].style.display = "none"; //稳定性较差
        $("#wendwenxc")[0].style.display = "none"; //稳定性差
        //稳定及变形情况 今后变化趋势
        $("#bianhuaqs")[0].style.display = "none";
        $("#bianhqsh")[0].style.display = "none"; //稳定性好
        $("#bianhqsjc")[0].style.display = "none"; //稳定性较差
        $("#bianhqsc")[0].style.display = "none"; //稳定性差
        //灾害影响及潜在威胁 造成危害
        $("#zaocweih")[0].style.display = "none"; //损坏房屋
        $("#ccwhshfw")[0].style.display = "none"; //损害房屋
        $("#ccwhhl")[0].style.display = "none"; //毁路
        $("#ccwhhq")[0].style.display = "none"; //毁渠
        $("#ccwhqtwh")[0].style.display = "none"; //其他危害
        //灾害影响及潜在威胁 潜在威胁
        $("#qianzwx")[0].style.display = "none"; //潜在威胁
        $("#qzwxwxrk")[0].style.display = "none"; //威胁人口
        $("#qzwxwxcc")[0].style.display = "none"; //威胁财产
        ////监测及防治情况 监测建议
        //$("#jiancejy")[0].style.display = "none"; //监测建议
        //$("#jcjydqmsjc")[0].style.display = "none"; //定期目视监测
        //$("#jcjyazjyjcss")[0].style.display = "none"; //安装简易监测设施
        //$("#jcjydmwyjc")[0].style.display = "none"; //地面位移监测
        //$("#jcjysbwyjc")[0].style.display = "none"; //深部位移监测
        ////监测及防治情况 防治建议
        //$("#fangzhijy")[0].style.display = "none"; //防治建议
        //$("#fzjyqcqf")[0].style.display = "none"; //群测群防
        //$("#fzjyzyjc")[0].style.display = "none"; //专业监测
        //$("#fzjybqbr")[0].style.display = "none"; //搬迁避让
        //$("#fzjygczl")[0].style.display = "none"; //工程治理

        $("#disasterCount").click(function () {//灾害点
            if ($("#disasterCount")[0].checked == true) {
                $("#zaihaiallcount")[0].style.display = "block";
            }
            else {
                clearcolor(); markname_statistics = false;
                $("#zaihaiallcount")[0].style.display = "none";
            }
        });

        $("#dangerousCount").click(function () {//隐患点
            if ($("#dangerousCount")[0].checked == true) {
                $("#yinhuandiancount")[0].style.display = "block";
                $("#yinhuandiancount p")[0].style.display = "block";
                $("#yinhuandiancount p")[0].style.color = "#000";
            }
            else {
                clearcolor(); markname_statistics = false;
                $("#yinhuandiancount")[0].style.display = "none";
            }
        });

        $("#huap").click(function () { //滑坡
            if ($("#huap")[0].checked == true) {
                $("#huaPo")[0].style.display = "block";
                $("#huaPo p")[0].style.color = "#000";
                $("#huaPo p")[0].style.display = "block";
                $("#huap ul li").each(function () {
                    $(this).css("display", "block");
                });
                if ($("#huap")[0].checked == true && $("#zhlxbengt")[0].checked == true && $("#zhlxxiep")[0].checked == true && $("#zhlxnisl")[0].checked == true && $("#zhlxdimcj")[0].checked == true && $("#zhlxdilf")[0].checked == true && $("#zhlxtax")[0].checked == true) {
                    $("#allzh")[0].checked = true;
                }
            }
            else {
                // if ($("#huaPo p")[0].style.color == "green") {
                clearcolor();
                markname_statistics = false;
                //   }
                $("#huaPo")[0].style.display = "none";
                $("#allzh")[0].checked = false;
            }
        });

        $("#zhlxbengt").click(function () { //崩塌
            if ($("#zhlxbengt")[0].checked == true) {
                $("#bengTa")[0].style.display = "block";
                $("#bengTa p")[0].style.color = "#000";
                $("#bengTa p")[0].style.display = "block";
                $("#bengTa ul li").each(function () {
                    $(this).css("display", "block");
                });
                if ($("#huap")[0].checked == true && $("#zhlxbengt")[0].checked == true && $("#zhlxxiep")[0].checked == true && $("#zhlxnisl")[0].checked == true && $("#zhlxdimcj")[0].checked == true && $("#zhlxdilf")[0].checked == true && $("#zhlxtax")[0].checked == true) {
                    $("#allzh")[0].checked = true;
                }
            }
            else {
                clearcolor(); markname_statistics = false;
                $("#bengTa")[0].style.display = "none";
                $("#allzh")[0].checked = false;
            }
        });

        $("#zhlxxiep").click(function () { //斜坡
            if ($("#zhlxxiep")[0].checked == true) {
                $("#xiePo")[0].style.display = "block";
                $("#xiePo p")[0].style.display = "block";
                $("#xiePo p")[0].style.color = "#000";
                $("#xiePo ul li").each(function () {
                    $(this).css("display", "block");
                });
                if ($("#huap")[0].checked == true && $("#zhlxbengt")[0].checked == true && $("#zhlxxiep")[0].checked == true && $("#zhlxnisl")[0].checked == true && $("#zhlxdimcj")[0].checked == true && $("#zhlxdilf")[0].checked == true && $("#zhlxtax")[0].checked == true) {
                    $("#allzh")[0].checked = true;
                }
            }
            else {
                clearcolor(); markname_statistics = false;
                $("#xiePo")[0].style.display = "none";
                $("#allzh")[0].checked = false;
            }
        });

        $("#zhlxnisl").click(function () { //泥石流
            if ($("#zhlxnisl")[0].checked == true) {
                $("#nishiLiu")[0].style.display = "block";
                $("#nishiLiu p")[0].style.display = "block";
                $("#nishiLiu p")[0].style.color = "#000";
                $("#nishiLiu ul li").each(function () {
                    $(this).css("display", "block");
                });
                if ($("#huap ")[0].checked == true && $("#zhlxbengt")[0].checked == true && $("#zhlxxiep")[0].checked == true && $("#zhlxnisl")[0].checked == true && $("#zhlxdimcj")[0].checked == true && $("#zhlxdilf")[0].checked == true && $("#zhlxtax")[0].checked == true) {
                    $("#allzh")[0].checked = true;
                }
            }
            else {
                clearcolor(); markname_statistics = false;
                $("#nishiLiu")[0].style.display = "none";
                $("#allzh")[0].checked = false;
            }
        });

        $("#zhlxdimcj").click(function () { //地面沉降
            if ($("#zhlxdimcj")[0].checked == true) {
                $("#dimcj")[0].style.display = "block";
                $("#dimcj p")[0].style.display = "block";
                $("#dimcj p")[0].style.color = "#000";
                $("#dimcj ul li").each(function () {
                    $(this).css("display", "block");
                });
                if ($("#huap")[0].checked == true && $("#zhlxbengt")[0].checked == true && $("#zhlxxiep")[0].checked == true && $("#zhlxnisl")[0].checked == true && $("#zhlxdimcj")[0].checked == true && $("#zhlxdilf")[0].checked == true && $("#zhlxtax")[0].checked == true) {
                    $("#allzh")[0].checked = true;
                }
            }
            else {
                clearcolor(); markname_statistics = false;
                $("#dimcj")[0].style.display = "none";
                $("#allzh")[0].checked = false;
            }
        });

        $("#zhlxdilf").click(function () { //地裂缝
            if ($("#zhlxdilf")[0].checked == true) {
                $("#dilieFeng")[0].style.display = "block";
                $("#dilieFeng p")[0].style.display = "block";
                $("#dilieFeng p")[0].style.color = "#000";
                $("#dilieFeng ul li").each(function () {
                    $(this).css("display", "block");
                });
                if ($("#huap")[0].checked == true && $("#zhlxbengt")[0].checked == true && $("#zhlxxiep")[0].checked == true && $("#zhlxnisl")[0].checked == true && $("#zhlxdimcj")[0].checked == true && $("#zhlxdilf")[0].checked == true && $("#zhlxtax")[0].checked == true) {
                    $("#allzh")[0].checked = true;
                }
            }
            else {
                clearcolor(); markname_statistics = false;
                $("#dilieFeng")[0].style.display = "none";
                $("#allzh")[0].checked = false;
            }
        });

        $("#zhlxtax").click(function () { //塌陷
            if ($("#zhlxtax")[0].checked == true) {
                $("#taXian")[0].style.display = "block";
                $("#taXian p")[0].style.display = "block";
                $("#taXian p")[0].style.color = "#000";
                $("#taXian ul li").each(function () {
                    $(this).css("display", "block");
                });
                if ($("#huap")[0].checked == true && $("#zhlxbengt")[0].checked == true && $("#zhlxxiep")[0].checked == true && $("#zhlxnisl")[0].checked == true && $("#zhlxdimcj")[0].checked == true && $("#zhlxdilf")[0].checked == true && $("#zhlxtax")[0].checked == true) {
                    $("#allzh")[0].checked = true;
                }
            }
            else {
                // if ($("#taXian p")[0].style.color == "green") {
                clearcolor(); markname_statistics = false;
                // }
                $("#taXian")[0].style.display = "none";
                $("#allzh")[0].checked = false;
            }
        });

        $("#allzh").click(function () {//灾害类型
            if ($("#allzh")[0].checked == true) {
                allzhlxcheck();
            }
            else {

                canclezhlxcheck();
            }
        });

        $("#allwendbxqk").click(function () {//稳定及变形情况
            if ($("#allwendbxqk")[0].checked == true) {
                allwdjbxqk();
            }
            else {
                canclewdjbxqk();
            }
        });

        $("#allzhyxjqzwx").click(function () {//灾害影响及潜在威胁
            if ($("#allzhyxjqzwx")[0].checked == true) {
                allzhyxjwx();
            }
            else {
                canclezhyxjwx();
            }
        });

        $("#alljcjfzqk").click(function () {//监测及防治情况
            if ($("#alljcjfzqk")[0].checked == true) {
                alljcjfzqk();
            }
            else {
                canclejcjfzqk();
            }
        });

        $("#allzxq").click(function () {//灾害影响及潜在威胁
            if ($("#allzxq")[0].checked == true) {
                allzxq();
            }
            else {
                canallzxq();
            }
        });

        $("#allcheck").click(function () {//全部选中
            $("#disasterCount")[0].checked = true;//灾害总数
            $("#dangerousCount")[0].checked = true;//隐患总数
            $("#zaihaiallcount")[0].style.display = "block";
            $("#yinhuandiancount")[0].style.display = "block";
            alljcjfzqk();
            allwdjbxqk();
            allzhlxcheck();
            allzhyxjwx();
            allzxq();
        });

        $("#canclecheck").click(function () {//全部取消
            $("#allzh")[0].checked = false;
            $("#allwendbxqk")[0].checked = false;
            $("#allzhyxjqzwx")[0].checked = false;
            $("#alljcjfzqk")[0].checked = false;
            $("#allzxq")[0].checked = false;

            $("#disasterCount")[0].checked = false;
            $("#dangerousCount")[0].checked = false;
            $("#zaihaiallcount")[0].style.display = "none";
            $("#yinhuandiancount")[0].style.display = "none";
            canclejcjfzqk();
            canclewdjbxqk();
            canclezhlxcheck();
            canclezhyxjwx();
            canallzxq();
        });

        //稳定及变形情况 目前稳定程度
        $("#wdwendxh").click(function () { //稳定性好
            if ($("#wdwendxh")[0].checked == true) {
                $("#wendingcd")[0].style.display = "block";
                $("#wendwendxh")[0].style.display = "block";
                $("#wendingcd p")[0].style.color = "#000";
                $("#wendwendxh")[0].style.color = "#000";
                if ($("#wdwendxh")[0].checked == true && $("#wdwendxjc")[0].checked == true && $("#wdwendxc")[0].checked == true) {
                    $("#allwendbxqk")[0].checked = true;
                }
            }
            else {
                if ($("#wdwendxh")[0].checked == false && $("#wdwendxjc")[0].checked == false && $("#wdwendxc")[0].checked == false) {
                    $("#wendingcd")[0].style.display = "none";
                }
                // if ($("#wendwendxh p")[0].style.color == "green") {
                clearcolor(); markname_statistics = false;
                // }
                $("#wendwendxh")[0].style.display = "none";
                $("#allwendbxqk")[0].checked = false;

            }
        });

        $("#wdwendxjc").click(function () { //稳定性较差
            if ($("#wdwendxjc")[0].checked == true) {
                $("#wendingcd")[0].style.display = "block";
                $("#wendwendxjc")[0].style.display = "block";
                $("#wendingcd p")[0].style.color = "#000";
                $("#wendwendxjc")[0].style.color = "#000";
                if ($("#wdwendxh")[0].checked == true && $("#wdwendxjc")[0].checked == true && $("#wdwendxc")[0].checked == true) {
                    $("#allwendbxqk")[0].checked = true;
                }
            }
            else {
                if ($("#wdwendxh")[0].checked == false && $("#wdwendxjc")[0].checked == false && $("#wdwendxc")[0].checked == false) {
                    $("#wendingcd")[0].style.display = "none";
                }
                //if ($("#wendwendxjc p")[0].style.color == "green") {
                clearcolor(); markname_statistics = false;
                //  }
                $("#wendwendxjc")[0].style.display = "none";
                $("#allwendbxqk")[0].checked = false;

            }
        });

        $("#wdwendxc").click(function () { //稳定性差
            if ($("#wdwendxc")[0].checked == true) {
                $("#wendingcd")[0].style.display = "block";
                $("#wendwenxc")[0].style.display = "block";
                $("#wendingcd p")[0].style.color = "#000";
                $("#wendwenxc")[0].style.color = "#000";
                if ($("#wdwendxh")[0].checked == true && $("#wdwendxjc")[0].checked == true && $("#wdwendxc")[0].checked == true) {
                    $("#allwendbxqk")[0].checked = true;
                }
            }
            else {
                if ($("#wdwendxh")[0].checked == false && $("#wdwendxjc")[0].checked == false && $("#wdwendxc")[0].checked == false) {
                    $("#wendingcd")[0].style.display = "none";
                }
                // if ($("#wendwenxc p")[0].style.color == "green") {
                clearcolor(); markname_statistics = false;
                //  }
                $("#wendwenxc")[0].style.display = "none";
                $("#allwendbxqk")[0].checked = false;

            }
        });

        //稳定及变形情况 今后变化趋势
        $("#bhwendxh").click(function () { //稳定性好
            if ($("#bhwendxh")[0].checked == true) {
                $("#bianhuaqs")[0].style.display = "block";
                $("#bianhqsh")[0].style.display = "block";
                $("#bianhuaqs p")[0].style.color = "#000";
                $("#bianhqsh")[0].style.color = "#000";
                if ($("#bhwendxh")[0].checked == true && $("#bhwendxjc")[0].checked == true && $("#bhwendxc")[0].checked == true) {
                    $("#allwendbxqk")[0].checked = true;
                }
            }
            else {
                if ($("#bhwendxh")[0].checked == false && $("#bhwendxjc")[0].checked == false && $("#bhwendxc")[0].checked == false) {
                    $("#bianhuaqs")[0].style.display = "none";
                }
                // if ($("#bianhqsh p")[0].style.color == "green") {
                clearcolor(); markname_statistics = false;
                //  }
                $("#bianhqsh")[0].style.display = "none";
                $("#allwendbxqk")[0].checked = false;

            }
        });

        $("#bhwendxjc").click(function () { //稳定性较差
            if ($("#bhwendxjc")[0].checked == true) {
                $("#bianhuaqs")[0].style.display = "block";
                $("#bianhqsjc")[0].style.display = "block";
                $("#bianhuaqs p")[0].style.color = "#000";
                $("#bianhqsjc")[0].style.color = "#000";
                if ($("#bhwendxh")[0].checked == true && $("#bhwendxjc")[0].checked == true && $("#bhwendxc")[0].checked == true) {
                    $("#allwendbxqk")[0].checked = true;
                }
            }
            else {
                if ($("#bhwendxh")[0].checked == false && $("#bhwendxjc")[0].checked == false && $("#bhwendxc")[0].checked == false) {
                    $("#bianhuaqs")[0].style.display = "none";
                }
                // if ($("#bianhqsjc p")[0].style.color == "green") {
                clearcolor(); markname_statistics = false;
                //  }
                $("#bianhqsjc")[0].style.display = "none";
                $("#allwendbxqk")[0].checked = false;
            }
        });

        $("#bhwendxc").click(function () { //稳定性差
            if ($("#bhwendxc")[0].checked == true) {
                $("#bianhuaqs")[0].style.display = "block";
                $("#bianhqsc")[0].style.display = "block";
                $("#bianhuaqs")[0].style.color = "#000";
                $("#bianhqsc")[0].style.color = "#000";
                if ($("#bhwendxh")[0].checked == true && $("#bhwendxjc")[0].checked == true && $("#bhwendxc")[0].checked == true) {
                    $("#allwendbxqk")[0].checked = true;
                }
            }
            else {
                if ($("#bhwendxh")[0].checked == false && $("#bhwendxjc")[0].checked == false && $("#bhwendxc")[0].checked == false) {
                    $("#bianhuaqs")[0].style.display = "none";
                }
                // if ($("#bianhqsc p")[0].style.color == "green") {
                clearcolor(); markname_statistics = false;
                //  }
                $("#bianhqsc")[0].style.display = "none";
                $("#allwendbxqk")[0].checked = false;

            }
        });

        //灾害影响及潜在威胁 造成危害
        $("#shfw").click(function () { //损害房屋
            if ($("#shfw")[0].checked == true) {
                $("#zaocweih")[0].style.display = "block";
                $("#ccwhshfw")[0].style.display = "block";
                $("#zaocweih")[0].style.color = "#000";//给默认颜色
                $("#ccwhshfw")[0].style.color = "#000";
                if ($("#shfw")[0].checked == true && $("#huil")[0].checked == true && $("#huiqu")[0].checked == true && $("#qitwh")[0].checked == true) {
                    $("#allzhyxjqzwx")[0].checked = true;
                }
            }
            else {
                if ($("#shfw")[0].checked == false && $("#huil")[0].checked == false && $("#huiqu")[0].checked == false && $("#qitwh")[0].checked == false) {
                    $("#zaocweih")[0].style.display = "none";
                }
                // if ($("#ccwhshfw p")[0].style.color == "green") {
                clearcolor(); markname_statistics = false;
                //  }
                $("#ccwhshfw")[0].style.display = "none";
                $("#allzhyxjqzwx")[0].checked = false;
            }
        });

        $("#huil").click(function () { //毁路
            if ($("#huil")[0].checked == true) {
                $("#zaocweih")[0].style.display = "block";
                $("#ccwhhl")[0].style.display = "block";
                $("#zaocweih")[0].style.color = "#000";
                $("#ccwhhl")[0].style.color = "#000";
                if ($("#shfw")[0].checked == true && $("#huil")[0].checked == true && $("#huiqu")[0].checked == true && $("#qitwh")[0].checked == true) {
                    $("#allzhyxjqzwx")[0].checked = true;
                }
            }
            else {
                if ($("#shfw")[0].checked == false && $("#huil")[0].checked == false && $("#huiqu")[0].checked == false && $("#qitwh")[0].checked == false) {
                    $("#zaocweih")[0].style.display = "none";
                }
                // if ($("#ccwhhl p")[0].style.color == "green") {
                clearcolor(); markname_statistics = false;
                //  }
                $("#ccwhhl")[0].style.display = "none";
                $("#allzhyxjqzwx")[0].checked = false;

            }
        });

        $("#huiqu").click(function () { //毁渠
            if ($("#huiqu")[0].checked == true) {
                $("#zaocweih")[0].style.display = "block";
                $("#ccwhhq")[0].style.display = "block";
                $("#zaocweih")[0].style.color = "#000";
                $("#ccwhhq")[0].style.color = "#000";
                if ($("#shfw")[0].checked == true && $("#huil")[0].checked == true && $("#huiqu")[0].checked == true && $("#qitwh")[0].checked == true) {
                    $("#allzhyxjqzwx")[0].checked = true;
                }
            }
            else {
                if ($("#shfw")[0].checked == false && $("#huil")[0].checked == false && $("#huiqu")[0].checked == false && $("#qitwh")[0].checked == false) {
                    $("#zaocweih")[0].style.display = "none";
                }
                //if ($("#ccwhhq p")[0].style.color == "green") {
                clearcolor(); markname_statistics = false;
                //  }
                $("#ccwhhq")[0].style.display = "none";
                $("#allzhyxjqzwx")[0].checked = false;

            }
        });

        $("#qitwh").click(function () { //其他危害
            if ($("#qitwh")[0].checked == true) {
                $("#zaocweih")[0].style.display = "block";
                $("#ccwhqtwh")[0].style.display = "block";
                $("#zaocweih")[0].style.color = "#000";
                $("#ccwhqtwh")[0].style.color = "#000";
                if ($("#shfw")[0].checked == true && $("#huil")[0].checked == true && $("#huiqu")[0].checked == true && $("#qitwh")[0].checked == true) {
                    $("#allzhyxjqzwx")[0].checked = true;
                }
            }
            else {
                if ($("#shfw")[0].checked == false && $("#huil")[0].checked == false && $("#huiqu")[0].checked == false && $("#qitwh")[0].checked == false) {
                    $("#zaocweih")[0].style.display = "none";
                }
                // if ($("#ccwhqtwh p")[0].style.color == "green") {
                clearcolor(); markname_statistics = false;
                // }
                $("#ccwhqtwh")[0].style.display = "none";
                $("#allzhyxjqzwx")[0].checked = false;

            }
        });

        //灾害影响及潜在威胁 潜在威胁
        $("#qianzwxweixrk").click(function () { //威胁人口
            if ($("#qianzwxweixrk")[0].checked == true) {
                $("#qianzwx")[0].style.display = "block";
                $("#qzwxwxrk")[0].style.display = "block";
                $("#qianzwx")[0].style.color = "#000";
                $("#qzwxwxrk")[0].style.color = "#000";
                if ($("#qianzwxweixrk")[0].checked == true && $("#qianzwxweixcc")[0].checked == true) {
                    $("#allzhyxjqzwx")[0].checked = true;
                }
            }
            else {
                if ($("#qianzwxweixrk")[0].checked == false && $("#qianzwxweixcc")[0].checked == false) {
                    $("#qianzwx")[0].style.display = "none";
                }
                // if ($("#qzwxwxrk p")[0].style.color == "green") {
                clearcolor(); markname_statistics = false;
                // }
                $("#qzwxwxrk")[0].style.display = "none";
                $("#allzhyxjqzwx")[0].checked = false;

            }
        });

        $("#qianzwxweixcc").click(function () { //威胁财产
            if ($("#qianzwxweixcc")[0].checked == true) {
                $("#qianzwx")[0].style.display = "block";
                $("#qzwxwxcc")[0].style.display = "block";
                $("#qianzwx")[0].style.color = "#000";
                $("#qzwxwxcc")[0].style.color = "#000";
                if ($("#qianzwxweixrk")[0].checked == true && $("#qianzwxweixcc")[0].checked == true) {
                    $("#allzhyxjqzwx")[0].checked = true;
                }
            }
            else {
                if ($("#qianzwxweixrk")[0].checked == false && $("#qianzwxweixcc")[0].checked == false) {
                    $("#qianzwx")[0].style.display = "none";
                }
                // if ($("#qzwxwxcc p")[0].style.color == "green") {
                clearcolor(); markname_statistics = false;
                //  }
                $("#qzwxwxcc")[0].style.display = "none";
                $("#allzhyxjqzwx")[0].checked = false;

            }
        });

        ////监测及防治情况 监测建议
        $("#dingqmsjc").click(function () { //定期目视监测
            if ($("#dingqmsjc")[0].checked == true) {
                $("#jiancejy")[0].style.display = "block";
                $("#jcjydqmsjc")[0].style.display = "block";
                $("#jiancejy")[0].style.color = "#000";
                $("#jcjydqmsjc")[0].style.color = "#000";
                if ($("#dingqmsjc")[0].checked == true && $("#anzjyjcss")[0].checked == true && $("#dimwyjc")[0].checked == true && $("#shebbwyjc")[0].checked == true) {
                    $("#alljcjfzqk")[0].checked = true;
                }
            }
            else {
                if ($("#dingqmsjc")[0].checked == false && $("#anzjyjcss")[0].checked == false && $("#dimwyjc")[0].checked == false && $("#shebbwyjc")[0].checked == false) {
                    $("#jiancejy")[0].style.display = "none";
                }
                //if ($("#jcjydqmsjc p")[0].style.color == "green") {
                clearcolor(); markname_statistics = false;
                // }
                $("#jcjydqmsjc")[0].style.display = "none";
                $("#alljcjfzqk")[0].checked = false;

            }
        });

        $("#anzjyjcss").click(function () { //安装简易监测设施
            if ($("#anzjyjcss")[0].checked == true) {
                $("#jiancejy")[0].style.display = "block";
                $("#jcjyazjyjcss")[0].style.display = "block";
                $("#jiancejy p")[0].style.color = "#000";
                $("#jcjyazjyjcss")[0].style.color = "#000";
                if ($("#dingqmsjc")[0].checked == true && $("#anzjyjcss")[0].checked == true && $("#dimwyjc")[0].checked == true && $("#shebbwyjc")[0].checked == true) {
                    $("#alljcjfzqk")[0].checked = true;
                }
            }
            else {
                if ($("#dingqmsjc")[0].checked == false && $("#anzjyjcss")[0].checked == false && $("#dimwyjc")[0].checked == false && $("#shebbwyjc")[0].checked == false) {
                    $("#jiancejy")[0].style.display = "none";
                }
                // if ($("#jcjyazjyjcss p")[0].style.color == "green") {
                clearcolor(); markname_statistics = false;
                // }
                $("#jcjyazjyjcss")[0].style.display = "none";
                $("#alljcjfzqk")[0].checked = false;

            }
        });

        $("#dimwyjc").click(function () { //地面位移监测
            if ($("#dimwyjc")[0].checked == true) {
                $("#jiancejy")[0].style.display = "block";
                $("#jcjydmwyjc")[0].style.display = "block";
                $("#jiancejy p")[0].style.color = "#000";
                $("#jcjydmwyjc")[0].style.color = "#000";
                if ($("#dingqmsjc")[0].checked == true && $("#anzjyjcss")[0].checked == true && $("#dimwyjc")[0].checked == true && $("#shebbwyjc")[0].checked == true) {
                    $("#alljcjfzqk")[0].checked = true;
                }
            }
            else {
                if ($("#dingqmsjc")[0].checked == false && $("#anzjyjcss")[0].checked == false && $("#dimwyjc")[0].checked == false && $("#shebbwyjc")[0].checked == false) {
                    $("#jiancejy")[0].style.display = "none";
                }
                // if ($("#jcjydmwyjc p")[0].style.color == "green") {
                clearcolor(); markname_statistics = false;
                // }
                $("#jcjydmwyjc")[0].style.display = "none";
                $("#alljcjfzqk")[0].checked = false;

            }
        });

        $("#shebbwyjc").click(function () { //深部位移监测
            if ($("#shebbwyjc")[0].checked == true) {
                $("#jiancejy")[0].style.display = "block";
                $("#jcjysbwyjc")[0].style.display = "block";
                $("#jiancejy p")[0].style.color = "#000";
                $("#jcjysbwyjc")[0].style.color = "#000";
                if ($("#dingqmsjc")[0].checked == true && $("#anzjyjcss")[0].checked == true && $("#dimwyjc")[0].checked == true && $("#shebbwyjc")[0].checked == true) {
                    $("#alljcjfzqk")[0].checked = true;
                }
            }
            else {
                if ($("#dingqmsjc")[0].checked == false && $("#anzjyjcss")[0].checked == false && $("#dimwyjc")[0].checked == false && $("#shebbwyjc")[0].checked == false) {
                    $("#jiancejy")[0].style.display = "none";
                }
                //if ($("#jcjysbwyjc p")[0].style.color == "green") {
                clearcolor(); markname_statistics = false;
                // }
                $("#jcjysbwyjc")[0].style.display = "none";
                $("#alljcjfzqk")[0].checked = false;

            }
        });

        //监测及防治情况 防治建议
        $("#quncqf").click(function () { //群测群防
            if ($("#quncqf")[0].checked == true) {
                $("#fangzhijy")[0].style.display = "block";
                $("#fzjyqcqf")[0].style.display = "block";
                $("#fangzhijy p")[0].style.color = "#000";
                $("#fzjyqcqf")[0].style.color = "#000";
                if ($("#dingqmsjc")[0].checked == true && $("#anzjyjcss")[0].checked == true && $("#dimwyjc")[0].checked == true && $("#shebbwyjc")[0].checked == true) {
                    $("#alljcjfzqk")[0].checked = true;
                }
            }
            else {
                if ($("#quncqf")[0].checked == false && $("#zhuanyjc")[0].checked == false && $("#banqbr")[0].checked == false && $("#gongczl")[0].checked == false) {
                    $("#fangzhijy")[0].style.display = "none";
                }
                // if ($("#fzjyqcqf p")[0].style.color == "green") {
                clearcolor(); markname_statistics = false;
                //  }
                $("#fzjyqcqf")[0].style.display = "none";
                $("#alljcjfzqk")[0].checked = false;
            }
        });

        $("#zhuanyjc").click(function () { //专业监测
            if ($("#zhuanyjc")[0].checked == true) {
                $("#fangzhijy")[0].style.display = "block";
                $("#fzjyzyjc")[0].style.display = "block";
                $("#fangzhijy p")[0].style.color = "#000";
                $("#fzjyzyjc")[0].style.color = "#000";
                if ($("#dingqmsjc")[0].checked == true && $("#anzjyjcss")[0].checked == true && $("#dimwyjc")[0].checked == true && $("#shebbwyjc")[0].checked == true) {
                    $("#alljcjfzqk")[0].checked = true;
                }
            }
            else {
                if ($("#quncqf")[0].checked == false && $("#zhuanyjc")[0].checked == false && $("#banqbr")[0].checked == false && $("#gongczl")[0].checked == false) {
                    $("#fangzhijy")[0].style.display = "none";
                }
                // if ($("#fzjyzyjc p")[0].style.color == "green") {
                clearcolor(); markname_statistics = false;
                // }
                $("#fzjyzyjc")[0].style.display = "none";
                $("#alljcjfzqk")[0].checked = false;
            }
        });

        $("#banqbr").click(function () { //避迁避让
            if ($("#banqbr")[0].checked == true) {
                $("#fangzhijy")[0].style.display = "block";
                $("#fzjybqbr")[0].style.display = "block";
                $("#fangzhijy p")[0].style.color = "#000";
                $("#fzjybqbr")[0].style.color = "#000";
                if ($("#dingqmsjc")[0].checked == true && $("#anzjyjcss")[0].checked == true && $("#dimwyjc")[0].checked == true && $("#shebbwyjc")[0].checked == true) {
                    $("#alljcjfzqk")[0].checked = true;
                }
            }
            else {
                if ($("#quncqf")[0].checked == false && $("#zhuanyjc")[0].checked == false && $("#banqbr")[0].checked == false && $("#gongczl")[0].checked == false) {
                    $("#fangzhijy")[0].style.display = "none";
                }
                // if ($("#fzjybqbr p")[0].style.color == "green") {
                clearcolor(); markname_statistics = false;
                //  }
                $("#fzjybqbr")[0].style.display = "none";
                $("#alljcjfzqk")[0].checked = false;
            }
        });

        $("#gongczl").click(function () { //工程治理
            if ($("#gongczl")[0].checked == true) {
                $("#fangzhijy")[0].style.display = "block";
                $("#fzjygczl")[0].style.display = "block";
                $("#fangzhijy p")[0].style.color = "#000";
                $("#fzjygczl")[0].style.color = "#000";
                if ($("#dingqmsjc")[0].checked == true && $("#anzjyjcss")[0].checked == true && $("#dimwyjc")[0].checked == true && $("#shebbwyjc")[0].checked == true) {
                    $("#alljcjfzqk")[0].checked = true;
                }
            }
            else {
                if ($("#quncqf")[0].checked == false && $("#zhuanyjc")[0].checked == false && $("#banqbr")[0].checked == false && $("#gongczl")[0].checked == false) {
                    $("#fangzhijy")[0].style.display = "none";
                }
                // if ($("#fzjygczl p")[0].style.color == "green") {
                clearcolor(); markname_statistics = false;
                // }
                $("#fzjygczl")[0].style.display = "none";
                $("#alljcjfzqk")[0].checked = false;
            }
        });



        //$("#zqxx").click(function () { //毁渠
        //    if ($("#zqxx")[0].checked == true) {
        //        $("#zaiqingxx")[0].style.display = "block";
        //        $("#zaiqingxx")[0].style.color = "#000";
        //        if ($("#shfw")[0].checked == true && $("#huil")[0].checked == true && $("#huiqu")[0].checked == true && $("#qitwh")[0].checked == true) {
        //            $("#allzhyxjqzwx")[0].checked = true;
        //        }
        //    }
        //    else {
        //        if ($("#shfw")[0].checked == false && $("#huil")[0].checked == false && $("#huiqu")[0].checked == false && $("#qitwh")[0].checked == false) {
        //            $("#zaocweih")[0].style.display = "none";
        //        }
        //        clearcolor(); markname_statistics = false;
        //        $("#ccwhhq")[0].style.display = "none";
        //        $("#allzhyxjqzwx")[0].checked = false;

        //    }
        //});

        //灾情小型
        $("#zqxx").click(function () { //稳定性好
            if ($("#zqxx")[0].checked == true) {
                $("#zaiqing")[0].style.display = "block";
                $("#zaiqingxx")[0].style.display = "block";
                $("#zaiqing p")[0].style.color = "#000";
                $("#zaiqingxx")[0].style.color = "#000";
                if ($("#zqxx")[0].checked == true && $("#zqzx")[0].checked == true && $("#zqdx")[0].checked == true && $("#zqtdx")[0].checked == true) {
                    $("#allzxq")[0].checked = true;
                }
            }
            else {
                if ($("#zqxx")[0].checked == false && $("#zqzx")[0].checked == false && $("#zqdx")[0].checked == false && $("#zqtdx")[0].checked == false) {
                    $("#zaiqing")[0].style.display = "none";
                }
                clearcolor(); markname_statistics = false;
                $("#zaiqingxx")[0].style.display = "none";
                $("#allzxq")[0].checked = false;

            }
        });
        //灾情中型
        $("#zqzx").click(function () { //稳定性好
            if ($("#zqzx")[0].checked == true) {
                $("#zaiqing")[0].style.display = "block";
                $("#zaiqingzx")[0].style.display = "block";
                $("#zaiqing p")[0].style.color = "#000";
                $("#zaiqingzx")[0].style.color = "#000";
                if ($("#zqxx")[0].checked == true && $("#zqzx")[0].checked == true && $("#zqdx")[0].checked == true && $("#zqtdx")[0].checked == true) {
                    $("#allzxq")[0].checked = true;
                }
            }
            else {
                if ($("#zqxx")[0].checked == false && $("#zqzx")[0].checked == false && $("#zqdx")[0].checked == false && $("#zqtdx")[0].checked == false) {
                    $("#zaiqing")[0].style.display = "none";
                }
                clearcolor(); markname_statistics = false;
                $("#zaiqingzx")[0].style.display = "none";
                $("#allzxq")[0].checked = false;

            }
        });
        //灾情大型
        $("#zqdx").click(function () { //稳定性好
            if ($("#zqdx")[0].checked == true) {
                $("#zaiqing")[0].style.display = "block";
                $("#zaiqingdx")[0].style.display = "block";
                $("#zaiqing p")[0].style.color = "#000";
                $("#zaiqingdx")[0].style.color = "#000";
                if ($("#zqxx")[0].checked == true && $("#zqzx")[0].checked == true && $("#zqdx")[0].checked == true && $("#zqtdx")[0].checked == true) {
                    $("#allzxq")[0].checked = true;
                }
            }
            else {
                if ($("#zqxx")[0].checked == false && $("#zqzx")[0].checked == false && $("#zqdx")[0].checked == false && $("#zqtdx")[0].checked == false) {
                    $("#zaiqing")[0].style.display = "none";
                }
                clearcolor(); markname_statistics = false;
                $("#zaiqingdx")[0].style.display = "none";
                $("#allzxq")[0].checked = false;

            }
        });
        //灾情特大型
        $("#zqtdx").click(function () { //稳定性好
            if ($("#zqtdx")[0].checked == true) {
                $("#zaiqing")[0].style.display = "block";
                $("#zaiqingtdx")[0].style.display = "block";
                $("#zaiqing p")[0].style.color = "#000";
                $("#zaiqingtdx")[0].style.color = "#000";
                if ($("#zqxx")[0].checked == true && $("#zqzx")[0].checked == true && $("#zqdx")[0].checked == true && $("#zqtdx")[0].checked == true) {
                    $("#allzxq")[0].checked = true;
                }
            }
            else {
                if ($("#zqxx")[0].checked == false && $("#zqzx")[0].checked == false && $("#zqdx")[0].checked == false && $("#zqtdx")[0].checked == false) {
                    $("#zaiqing")[0].style.display = "none";
                }
                clearcolor(); markname_statistics = false;
                $("#zaiqingtdx")[0].style.display = "none";
                $("#allzxq")[0].checked = false;

            }
        });


        //险情小型
        $("#xqxx").click(function () { //稳定性好
            if ($("#xqxx")[0].checked == true) {
                $("#xianqing")[0].style.display = "block";
                $("#xianqingxx")[0].style.display = "block";
                $("#xianqing p")[0].style.color = "#000";
                $("#xianqingxx")[0].style.color = "#000";
                if ($("#xqxx")[0].checked == true && $("#xqzx")[0].checked == true && $("#xqdx")[0].checked == true && $("#xqtdx")[0].checked == true) {
                    $("#allzxq")[0].checked = true;
                }
            }
            else {
                if ($("#xqxx")[0].checked == false && $("#xqzx")[0].checked == false && $("#xqdx")[0].checked == false && $("#xqtdx")[0].checked == false) {
                    $("#xianqing")[0].style.display = "none";
                }
                clearcolor(); markname_statistics = false;
                $("#xianqingxx")[0].style.display = "none";
                $("#allzxq")[0].checked = false;

            }
        });
        //险情大型
        $("#xqdx").click(function () { //稳定性好
            if ($("#xqdx")[0].checked == true) {
                $("#xianqing")[0].style.display = "block";
                $("#xianqingdx")[0].style.display = "block";
                $("#xianqing p")[0].style.color = "#000";
                $("#xianqingdx")[0].style.color = "#000";
                if ($("#xqxx")[0].checked == true && $("#xqzx")[0].checked == true && $("#xqdx")[0].checked == true && $("#xqtdx")[0].checked == true) {
                    $("#allzxq")[0].checked = true;
                }
            }
            else {
                if ($("#xqxx")[0].checked == false && $("#xqzx")[0].checked == false && $("#xqdx")[0].checked == false && $("#xqtdx")[0].checked == false) {
                    $("#xianqing")[0].style.display = "none";
                }
                clearcolor(); markname_statistics = false;
                $("#xianqingdx")[0].style.display = "none";
                $("#allzxq")[0].checked = false;

            }
        });//险情小型
        $("#xqzx").click(function () { //稳定性好
            if ($("#xqzx")[0].checked == true) {
                $("#xianqing")[0].style.display = "block";
                $("#xianqingzx")[0].style.display = "block";
                $("#xianqing p")[0].style.color = "#000";
                $("#xianqingzx")[0].style.color = "#000";
                if ($("#xqxx")[0].checked == true && $("#xqzx")[0].checked == true && $("#xqdx")[0].checked == true && $("#xqtdx")[0].checked == true) {
                    $("#allzxq")[0].checked = true;
                }
            }
            else {
                if ($("#xqxx")[0].checked == false && $("#xqzx")[0].checked == false && $("#xqdx")[0].checked == false && $("#xqtdx")[0].checked == false) {
                    $("#xianqing")[0].style.display = "none";
                }
                clearcolor(); markname_statistics = false;
                $("#xianqingzx")[0].style.display = "none";
                $("#allzxq")[0].checked = false;

            }
        });//险情小型
        $("#xqtdx").click(function () { //稳定性好
            if ($("#xqtdx")[0].checked == true) {
                $("#xianqing")[0].style.display = "block";
                $("#xianqingtdx")[0].style.display = "block";
                $("#xianqing p")[0].style.color = "#000";
                $("#xianqingxx")[0].style.color = "#000";
                if ($("#xqxx")[0].checked == true && $("#xqzx")[0].checked == true && $("#xqdx")[0].checked == true && $("#xqtdx")[0].checked == true) {
                    $("#allzxq")[0].checked = true;
                }
            }
            else {
                if ($("#xqxx")[0].checked == false && $("#xqzx")[0].checked == false && $("#xqdx")[0].checked == false && $("#xqtdx")[0].checked == false) {
                    $("#xianqing")[0].style.display = "none";
                }
                clearcolor(); markname_statistics = false;
                $("#xianqingtdx")[0].style.display = "none";
                $("#allzxq")[0].checked = false;

            }
        });


        //下移
        $("#selectdown").click(function () {
            var maxindex = 0;
            var parentid = "";
            current_index = 0;
            if (markname_statistics) {
                $(".caidan p").each(function () {
                    if ($(this)[0].style.color == "green") {
                        var str = $(this).find("span")[0].innerHTML;
                        if (str != "") {
                            current_index = str.toString().split("|")[1];
                            divname = str.toString().split("|")[2];
                        }
                    }
                });
                $(".caidan li").each(function () {
                    if ($(this)[0].style.color == "green") {
                        var str = $(this).find("span")[0].innerHTML;
                        if (str != "") {
                            current_index = str.toString().split("|")[1];
                            maxindex = str.toString().split("|")[2];
                            parentid = str.toString().split("|")[3];
                        }
                    }
                });
                if (parent_statistics)//如果选中的是父级菜单
                {
                    if (parseInt(current_index) < 13) {
                        var current_text = $(".caidan")[current_index].innerHTML;//当前的文本
                        var current_id = $(".caidan ")[current_index].id;
                        var current_span = $(".caidan p span")[current_index].innerHTML
                        var newindex = parseInt(current_index) + 1;
                        //要判断是否为隐藏
                        newindex = downindex(newindex);
                        if (newindex == 14) {
                            return;
                        }
                        var up_text = $(".caidan")[newindex].innerHTML;
                        var up_id = $(".caidan")[newindex].id;
                        var up_span = $(".caidan p span")[newindex].innerHTML
                        $(".caidan")[current_index].innerHTML = up_text;
                        $(".caidan")[current_index].id = up_id;
                        $(".caidan p span")[current_index].innerHTML = "|" + current_index + "|" + up_id + "|" + up_span.split('|')[3];
                        $(".caidan")[newindex].innerHTML = current_text;
                        $(".caidan")[newindex].id = current_id;
                        $(".caidan p span")[newindex].innerHTML = "|" + newindex + "|" + current_id + "|" + current_span.split('|')[3];
                        object_statistics_p = $(".caidan")[newindex];
                        $(".caidan p")[current_index].onclick = function () {
                            current_index = 0;
                            parent_statistics = true;
                            markname_statistics = true;
                            object_statistics_p = $(this)[0];
                            //  alert(object_check);
                            clearcolor();
                            $(this).css("color", "green"); object_statistics = $(".caidan")[newindex];
                        }
                        $(".caidan p")[newindex].onclick = function () {
                            current_index = 0;
                            parent_statistics = true;
                            markname_statistics = true;
                            object_statistics_p = $(this)[0];
                            // alert(object_check);
                            clearcolor();
                            $(this).css("color", "green"); object_statistics = $(".caidan")[newindex];
                        }


                    }
                }
                else {//子菜单
                    if (parseInt(current_index) + 1 < maxindex) {

                        var curent_text = $("#" + parentid + " div")[current_index].innerHTML;
                        var current_id = $("#" + parentid + " li")[current_index].id;//当前li的id
                        var newindex = parseInt(current_index) + 1;
                        var up_text = $("#" + parentid + " div")[newindex].innerHTML;
                        var up_id = $("#" + parentid + " li")[newindex].id;
                        $("#" + parentid + " div")[current_index].innerHTML = up_text;
                        $("#" + parentid + " li")[current_index].id = up_id;
                        $("#" + parentid + " div")[newindex].innerHTML = curent_text;
                        $("#" + parentid + " li")[newindex].id = current_id;
                        $("#" + parentid + " li")[newindex].style.color = "green";
                        $("#" + parentid + " li")[current_index].style.color = "#000";
                        object_statistics = $("#" + parentid + " li")[newindex];
                    }


                }
            }
            else {
                alert(" 请选中要移动的项");
            }
        });

        //上移
        $("#selectup").click(function () {
            current_index = 0;
            var maxindex = 0;
            var parentid = "";
            if (markname_statistics) {
                $(".caidan p").each(function () {
                    if ($(this)[0].style.color == "green") {
                        var str = $(this).find("span")[0].innerHTML;
                        if (str != "") {
                            if (str.toString().split("|")[0] == "灾害总数") {
                                alert(123);
                            }
                            current_index = str.toString().split("|")[1];
                            divname = str.toString().split("|")[2];
                        }
                    }
                });
                $(".caidan li").each(function () {
                    if ($(this)[0].style.color == "green") {
                        var str = $(this).find("span")[0].innerHTML;
                        if (str != "") {
                            current_index = str.toString().split("|")[1];
                            maxindex = str.toString().split("|")[2];
                            parentid = str.toString().split("|")[3];
                        }
                    }
                });
                if (parent_statistics)//如果选中的是父级菜单
                {
                    if (current_index > 0) {
                        var current_text = $(".caidan")[current_index].innerHTML;//当前的文本
                        var current_id = $(".caidan ")[current_index].id;
                        var current_span = $(".caidan p span")[current_index].innerHTML
                        var newindex = parseInt(current_index) - 1;
                        newindex = upindex(newindex);
                        if (newindex == -1) {
                            return;
                        }
                        var up_text = $(".caidan")[newindex].innerHTML;
                        var up_id = $(".caidan")[newindex].id;
                        var up_span = $(".caidan p span")[newindex].innerHTML
                        $(".caidan")[current_index].innerHTML = up_text;
                        $(".caidan")[current_index].id = up_id;
                        $(".caidan p span")[current_index].innerHTML = "|" + current_index + "|" + up_id + up_span.split('|')[3];
                        $(".caidan")[newindex].innerHTML = current_text;
                        $(".caidan")[newindex].id = current_id;
                        $(".caidan p span")[newindex].innerHTML = "|" + newindex + "|" + current_id + current_span.split('|')[3];
                        object_statistics_p = $(".caidan")[newindex];
                        $(".caidan p")[current_index].onclick = function () {
                            current_index = 0;
                            parent_statistics = true;
                            markname_statistics = true;
                            object_statistics_p = $(this);
                            clearcolor();
                            // alert(object_check);
                            $(this).css("color", "green"); object_statistics = $(".caidan")[newindex];
                        }
                        $(".caidan p")[newindex].onclick = function () {
                            current_index = 0;
                            parent_statistics = true;
                            markname_statistics = true;
                            object_statistics_p = $(this);
                            // alert(object_check);
                            clearcolor();
                            $(this).css("color", "green"); object_statistics = $(".caidan")[current_index];
                        }


                    }
                }
                else {//子菜单
                    if (parseInt(current_index) - 1 >= 0) {

                        var curent_text = $("#" + parentid + " div")[current_index].innerHTML;
                        var current_id = $("#" + parentid + " li")[current_index].id;//当前li的id
                        var newindex = parseInt(current_index) - 1;
                        var up_text = $("#" + parentid + " div")[newindex].innerHTML;
                        var up_id = $("#" + parentid + " li")[newindex].id;
                        $("#" + parentid + " div")[current_index].innerHTML = up_text;
                        $("#" + parentid + " li")[current_index].id = up_id;
                        $("#" + parentid + " div")[newindex].innerHTML = curent_text;
                        $("#" + parentid + " li")[newindex].id = current_id;
                        $("#" + parentid + " li")[newindex].style.color = "green";
                        $("#" + parentid + " li")[current_index].style.color = "#000";
                        object_statistics = $("#" + parentid + " li")[newindex];

                    }


                }
            }
            else {


                alert(" 请选中要移动的项");
            }
        });

        //删除
        $("#delectselect").click(function () {

            if (markname_statistics) {
                if (object_statistics_p != null && object_statistics_p != "") {
                    if (object_check != "") {
                        $(".caidan p").each(function () {
                            if ($(this)[0].style.color == "green") {
                                var str = $(this).find("span")[0].innerHTML;
                                if (str != "") {
                                    object_check = str.toString().split("|")[3];
                                }
                            }
                        });
                    }

                    if (!parent_statistics) {//不是父节点
                        object_statistics.style.display = "none";
                        if (mark_statistics == true) {//不是七张表

                            var obj = txmark_statistics.split('|')[0];
                            var name = txmark_statistics.split('|')[1];
                            obj = obj.split(',');
                            for (var i = 0; i < obj.length; i++) {
                                $("#" + obj[i])[0].checked = false;
                            }
                            var index = false;
                            $("#" + name + " ul li").each(function () {
                                if ($(this)[0].style.display == "none") {
                                    index = true;
                                }
                                else {
                                    index = false;
                                }
                            });
                            if (index) {
                                $("#" + name)[0].style.display = "none";
                            }
                        }
                        else {//如果是七张表
                            var obj = txmark_statistics.split('|')[0];
                            var name = txmark_statistics.split('|')[1];
                            obj = obj.split(',');
                            $("#" + name + " ul li").each(function () {
                                if ($(this)[0].style.display == "none") {
                                    index = true;
                                }
                                else {
                                    index = false;
                                }
                            });
                            if (index) {
                                $("#" + name)[0].style.display = "none";
                                $("#" + obj[0])[0].checked = false;
                                $("#" + obj[1])[0].checked = false;
                            }
                        }
                        object_statistics.style.color = "#000";


                    }
                    else {//父节点
                        var obj = object_check.split(',');
                        for (var i = 0; i < obj.length; i++) {
                            $("#" + obj[i])[0].checked = false;
                        }
                        object_statistics_p.style.display = "none";

                    }
                    object_statistics_p.style.color = "#000";

                    markname_statistics = false;

                }
            }
            else {
                alert(" 请选中要删除的项");
            }
        });

        $("#checkall").click(function () {

        });
        $(".caidan p").click(function () {//父节点
            current_index = 0;
            parent_statistics = true;
            markname_statistics = true;
            clearcolor();
            $(this).css("color", "green");
            object_statistics = $(this);
            //object_statistics_p = $(this);
        });
        $(".caidan p").click(function () {//父节点
            current_index = 0;
            parent_statistics = true;
            markname_statistics = true;
            clearcolor();
            $(this).css("color", "green");
        });
        $(".caidan li").click(function () {//子节点
            current_index = 0;
            parent_statistics = false;
            markname_statistics = true;
            clearcolor();
            $(this).css("color", "green");

        });

        //递归得到 向下移动 得到display：block的索引 
        function downindex(newindex) {
            markindex = newindex;
            if (newindex <= 13) {

                if ($(".caidan")[newindex].style.display == "none") {
                    newindex++;
                    return downindex(newindex);
                }
                else {
                    return newindex;
                }
            }
            else {
                return 14;//最大索引为14
            }

        }
        //递归得到 向下移动 得到display：block的索引

        function upindex(newindex) {
            markindex = newindex;
            if (newindex >= 0) {

                if ($(".caidan")[newindex].style.display == "none") {
                    newindex--;
                    return upindex(newindex);
                }
                else {
                    return newindex;
                }
            }
            else {
                return -1;
            }
        }
        /*****************************************确定及取消事件*****************************************/

        //保存查询内容
        function SaveSelectDisasterType(value) {
            StatisticsSql = value;
            //$('#tjboxone').window('close');
            //$(".layui-layer-btn1").click();
        }
        function clearcolor() {
            $(".caidan p").each(function () {
                $(this).css("color", "#000");
            });
            $(".caidan li").each(function () {
                $(this).css("color", "#000");
            });
        }

        //清空查询内容
        function ClearSelectDisasterType() {
            StatisticsSql = "";

        }

        /*****************************************确定及取消事件*****************************************/

        //Modified by wx 2013.12.16
        //默认选中"灾害类型"和"灾害影响及潜在威胁"
        allwdjbxqk();
        allzhyxjwx();
        allzhlxcheck();
        allzxq();
        alljcjfzqk();
        $("#disasterCount")[0].checked = true; //
        $("#zaihaiallcount")[0].style.display = "block";
        $("#dangerousCount")[0].checked = true; //
        $("#yinhuandiancount")[0].style.display = "block";
        //页面加载默认选中值
        //StatisticsSql = getSelectVal();
    });
})

//取选中状态值
function getSelectVal() {
    var conStr = "";

    $("#treemenu ul li").each(function (index, li) {
        if (li.style.display == "block") {
            if (li.id == "bengTa" || li.id == "taXian" || li.id == "nishiLiu" || li.id == "dimcj" || li.id == "dilieFeng" || li.id == "huaPo" || li.id == "xiePo" || li.id == "zaihaiallcount" || li.id == "yinhuandiancount") {
                var str = li.children[0].innerHTML.split("<")[0];//<span>
                var mark = true;
                $("#" + li.id + " ul li").each(function () {
                    if ($(this)[0].style.display == "none" && $(this).text().split("|")[0] == str + "个数") {
                        mark = false;
                    }
                });
                if (mark) {
                    if (conStr == "") {

                        conStr = str;
                    }
                    else {
                        conStr += "," + str;
                    }
                }

            }
            else {
                if (li.parentNode && li.parentNode.parentNode && li.parentNode.parentNode.parentNode.id == "tree") {
                    var str = li.parentNode.parentNode.children[0].innerHTML.split("<")[0] + ":" + li.children[0].innerHTML.split("<")[0];
                    if (conStr == "") {
                        conStr = str;

                    }
                    else {
                        conStr += "," + str;
                    }
                }
            }
        }
    });
    return conStr;
}

//灾害类型
function allzhlxcheck() {
    $("#allzh")[0].checked = true;
    $("#huaPo")[0].style.display = "block"; //滑坡
    $("#bengTa")[0].style.display = "block"; //崩塌
    $("#taXian")[0].style.display = "block"; //塌陷
    $("#xiePo")[0].style.display = "block"; //斜坡
    $("#nishiLiu")[0].style.display = "block"; //泥石流
    $("#dimcj")[0].style.display = "block"; //地面沉降
    $("#dilieFeng")[0].style.display = "block"; //地裂缝
    //给默认颜色
    $("#huaPo p")[0].style.color = "#000"; //滑坡
    $("#bengTa p")[0].style.color = "#000"; //崩塌
    $("#taXian p")[0].style.color = "#000"; //塌陷
    $("#xiePo p")[0].style.color = "#000"; //斜坡
    $("#nishiLiu p")[0].style.color = "#000"; //泥石流
    $("#dimcj p")[0].style.color = "#000"; //地面沉降
    $("#dilieFeng p")[0].style.color = "#000"; //地裂缝
    $("#huap")[0].checked = true; //滑坡
    $("#zhlxbengt")[0].checked = true; //崩塌
    $("#zhlxxiep")[0].checked = true; //斜坡
    $("#zhlxnisl")[0].checked = true; //泥石流
    $("#zhlxdimcj")[0].checked = true; //地面沉降
    $("#zhlxdilf")[0].checked = true; //地裂缝
    $("#zhlxtax")[0].checked = true; //塌陷
}
//灾害类型
function canclezhlxcheck() {
    $("#huaPo")[0].style.display = "none"; //滑坡
    $("#bengTa")[0].style.display = "none"; //崩塌
    $("#taXian")[0].style.display = "none"; //塌陷
    $("#xiePo")[0].style.display = "none"; //斜坡
    $("#nishiLiu")[0].style.display = "none"; //泥石流
    $("#dimcj")[0].style.display = "none"; //地面沉降
    $("#dilieFeng")[0].style.display = "none"; //地裂缝

    $("#huap")[0].checked = false; //滑坡
    $("#zhlxbengt")[0].checked = false; //崩塌
    $("#zhlxxiep")[0].checked = false; //斜坡
    $("#zhlxnisl")[0].checked = false; //泥石流
    $("#zhlxdimcj")[0].checked = false; //地面沉降
    $("#zhlxdilf")[0].checked = false; //地裂缝
    $("#zhlxtax")[0].checked = false; //塌陷
}
//稳定及变形情况
function allwdjbxqk() {

    $("#allwendbxqk")[0].checked = true;

    $("#wendingcd")[0].style.display = "block"; //
    $("#bianhuaqs")[0].style.display = "block"; //

    $("#wendwendxh")[0].style.display = "block"; //
    $("#wendwendxjc")[0].style.display = "block"; //
    $("#wendwenxc")[0].style.display = "block"; //
    $("#bianhqsh")[0].style.display = "block"; //
    $("#bianhqsjc")[0].style.display = "block"; //
    $("#bianhqsc")[0].style.display = "block"; //
    //给默认颜色
    $("#wendingcd p")[0].style.color = "#000"; //
    $("#bianhuaqs p")[0].style.color = "#000"; //

    $("#wendwendxh")[0].style.color = "#000"; //
    $("#wendwendxjc")[0].style.color = "#000"; //
    $("#wendwenxc")[0].style.color = "#000"; //
    $("#bianhqsh")[0].style.color = "#000"; //
    $("#bianhqsjc")[0].style.color = "#000"; //
    $("#bianhqsc")[0].style.color = "#000"; //



    $("#wdwendxh")[0].checked = true; //
    $("#wdwendxjc")[0].checked = true; //
    $("#wdwendxc")[0].checked = true; //
    $("#bhwendxh")[0].checked = true; //
    $("#bhwendxjc")[0].checked = true; //
    $("#bhwendxc")[0].checked = true; //
}
//稳定及变形情况
function canclewdjbxqk() {

    $("#wendingcd")[0].style.display = "none"; //
    $("#bianhuaqs")[0].style.display = "none"; //

    $("#wendwendxh")[0].style.display = "none"; //
    $("#wendwendxjc")[0].style.display = "none"; //
    $("#wendwenxc")[0].style.display = "none"; //
    $("#bianhqsh")[0].style.display = "none"; //
    $("#bianhqsjc")[0].style.display = "none"; //
    $("#bianhqsc")[0].style.display = "none"; //
    $("#wdwendxh")[0].checked = false; //
    $("#wdwendxjc")[0].checked = false; //
    $("#wdwendxc")[0].checked = false; //
    $("#bhwendxh")[0].checked = false; //
    $("#bhwendxjc")[0].checked = false; //
    $("#bhwendxc")[0].checked = false; //
}
function allzhyxjwx() {
    $("#allzhyxjqzwx")[0].checked = true;
    $("#zaocweih")[0].style.display = "block"; //
    $("#qianzwx")[0].style.display = "block"; //
    $("#ccwhshfw")[0].style.display = "block"; //
    $("#ccwhhl")[0].style.display = "block"; //
    $("#ccwhhq")[0].style.display = "block"; //
    $("#ccwhqtwh")[0].style.display = "block"; //
    $("#qzwxwxrk")[0].style.display = "block"; //
    $("#qzwxwxcc")[0].style.display = "block"; //
    $("#qzwxwxhs")[0].style.display = "block"; //

    $("#zaocweih p")[0].style.color = "#000"; //
    $("#qianzwx p")[0].style.color = "#000"; //
    $("#ccwhshfw")[0].style.color = "#000"; //
    $("#ccwhhl")[0].style.color = "#000"; //
    $("#ccwhhq")[0].style.color = "#000"; //
    $("#ccwhqtwh")[0].style.color = "#000"; //
    $("#qzwxwxrk")[0].style.color = "#000"; //
    $("#qzwxwxcc")[0].style.color = "#000"; //
    $("#shfw")[0].checked = true; //
    $("#huil")[0].checked = true; //
    $("#huiqu")[0].checked = true; //
    $("#qitwh")[0].checked = true; //
    $("#qianzwxweixrk")[0].checked = true; //
    $("#qianzwxweixcc")[0].checked = true; //
    $("#qianzwxweixhs")[0].checked = true; //
}
function canclezhyxjwx() {
    $("#zaocweih")[0].style.display = "none"; //
    $("#qianzwx")[0].style.display = "none"; //
    $("#ccwhshfw")[0].style.display = "none"; //
    $("#ccwhhl")[0].style.display = "none"; //
    $("#ccwhhq")[0].style.display = "none"; //
    $("#ccwhqtwh")[0].style.display = "none"; //
    $("#qzwxwxrk")[0].style.display = "none"; //
    $("#qzwxwxcc")[0].style.display = "none"; //
    $("#shfw")[0].checked = false; //
    $("#huil")[0].checked = false; //
    $("#huiqu")[0].checked = false; //
    $("#qitwh")[0].checked = false; //
    $("#qianzwxweixrk")[0].checked = false; //
    $("#qianzwxweixcc")[0].checked = false; //


}

function alljcjfzqk() {
    $("#alljcjfzqk")[0].checked = true;
    $("#jiancejy")[0].style.display = "block"; //
    $("#fangzhijy")[0].style.display = "block"; //
    $("#jcjydqmsjc")[0].style.display = "block"; //
    $("#jcjyazjyjcss")[0].style.display = "block"; //
    $("#jcjydmwyjc")[0].style.display = "block"; //
    $("#jcjysbwyjc")[0].style.display = "block"; //
    $("#fzjyqcqf")[0].style.display = "block"; //
    $("#fzjyzyjc")[0].style.display = "block"; //
    $("#fzjybqbr")[0].style.display = "block"; //
    $("#fzjygczl")[0].style.display = "block"; //


    $("#jiancejy p")[0].style.color = "#000"; //
    $("#fangzhijy p")[0].style.color = "#000"; //
    $("#jcjydqmsjc")[0].style.color = "#000"; //
    $("#jcjyazjyjcss")[0].style.color = "#000"; //
    $("#jcjydmwyjc")[0].style.color = "#000"; //
    $("#jcjysbwyjc")[0].style.color = "#000"; //
    $("#fzjyqcqf")[0].style.color = "#000"; //
    $("#fzjyzyjc")[0].style.color = "#000"; //
    $("#fzjybqbr")[0].style.color = "#000"; //
    $("#fzjygczl")[0].style.color = "#000"; //
    $("#dingqmsjc")[0].checked = true; //
    $("#anzjyjcss")[0].checked = true; //
    $("#dimwyjc")[0].checked = true; //
    $("#shebbwyjc")[0].checked = true; //
    $("#quncqf")[0].checked = true; //
    $("#zhuanyjc")[0].checked = true; //
    $("#banqbr")[0].checked = true; //
    $("#gongczl")[0].checked = true; //
}
function canclejcjfzqk() {
    $("#jiancejy")[0].style.display = "none"; //
    $("#fangzhijy")[0].style.display = "none"; //
    $("#jcjydqmsjc")[0].style.display = "none"; //
    $("#jcjyazjyjcss")[0].style.display = "none"; //
    $("#jcjydmwyjc")[0].style.display = "none"; //
    $("#jcjysbwyjc")[0].style.display = "none"; //
    $("#fzjyqcqf")[0].style.display = "none"; //
    $("#fzjyzyjc")[0].style.display = "none"; //
    $("#fzjybqbr")[0].style.display = "none"; //
    $("#fzjygczl")[0].style.display = "none"; //

    $("#dingqmsjc")[0].checked = false; //
    $("#anzjyjcss")[0].checked = false; //
    $("#dimwyjc")[0].checked = false; //
    $("#shebbwyjc")[0].checked = false; //
    $("#quncqf")[0].checked = false; //
    $("#zhuanyjc")[0].checked = false; //
    $("#banqbr")[0].checked = false; //
    $("#gongczl")[0].checked = false; //

}
function allzxq() {
    $("#allzxq")[0].checked = true;
    $("#zaiqing")[0].style.display = "block"; //
    $("#xianqing")[0].style.display = "block"; //

    $("#zaiqingxx")[0].style.display = "block"; //
    $("#zaiqingzx")[0].style.display = "block"; //
    $("#zaiqingdx")[0].style.display = "block"; //
    $("#zaiqingtdx")[0].style.display = "block"; //

    $("#xianqingxx")[0].style.display = "block"; //
    $("#zaiqingzx")[0].style.display = "block"; //
    $("#zaiqingdx")[0].style.display = "block"; //
    $("#zaiqingtdx")[0].style.display = "block"; //


    $("#xianqing p")[0].style.color = "#000"; //
    $("#zaiqing p")[0].style.color = "#000"; //
    $("#zaiqingxx")[0].style.color = "#000"; //
    $("#zaiqingzx")[0].style.color = "#000"; //
    $("#zaiqingdx")[0].style.color = "#000"; //
    $("#zaiqingtdx")[0].style.color = "#000"; //

    $("#xianqingxx")[0].style.color = "#000"; //
    $("#zaiqingzx")[0].style.color = "#000"; //
    $("#zaiqingdx")[0].style.color = "#000"; //
    $("#zaiqingtdx")[0].style.color = "#000"; //

    $("#zqtdx")[0].checked = true; //
    $("#zqdx")[0].checked = true; //
    $("#zqzx")[0].checked = true; //
    $("#zqxx")[0].checked = true; //
    $("#xqxx")[0].checked = true; //
    $("#xqzx")[0].checked = true; //
    $("#xqdx")[0].checked = true; //
    $("#xqtdx")[0].checked = true; //
}
function canallzxq() {
    $("#xianqing")[0].style.display = "none"; //
    $("#zaiqing")[0].style.display = "none"; //
    $("#zaiqingxx")[0].style.display = "none"; //
    $("#zaiqingzx")[0].style.display = "none"; //
    $("#zaiqingdx")[0].style.display = "none"; //
    $("#zaiqingtdx")[0].style.display = "none"; //
    $("#xianqingxx")[0].style.display = "none"; //
    $("#zaiqingzx")[0].style.display = "none"; //
    $("#zaiqingdx")[0].style.display = "none"; //
    $("#zaiqingtdx")[0].style.display = "none"; //

    $("#zqtdx")[0].checked = false; //
    $("#zqdx")[0].checked = false; //
    $("#zqzx")[0].checked = false; //
    $("#zqxx")[0].checked = false; //
    $("#xqxx")[0].checked = false; //
    $("#xqzx")[0].checked = false; //
    $("#xqdx")[0].checked = false; //
    $("#xqtdx")[0].checked = false; //

}
