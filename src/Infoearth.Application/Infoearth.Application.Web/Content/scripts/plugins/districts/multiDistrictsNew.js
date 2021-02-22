(function ($) {
    $.fn.mulDistrictsCtl = function (settings) {
        var _coordSys = "";
        var _isProjectiveGeo = ""; var djcode = "";
        //默认选项
        var defaluts =
            {
                provinceId: "",//初始化省的个数
                selectProviceId: "",//选中省
                selectCityId: "",//选中市
                selectCounty: "",//选中县
                selectTown: "",//选中乡镇
                showTown: true,
                html: "",
                type: 'T',
            };
        defaluts.provinceId = settings.provinceId;
        $.extend(defaluts, settings);
        var _district = $(this).empty();
        var _html;
        if (defaluts.html) {
            _html = defaluts.html;
        }
        else {
            if (defaluts.type == 'B') {
                _html = '<div style="float: left;width:100%;align-items: center;flex-wrap: nowrap;">';
                _html += '<div class="tiaoj"><span class="spans" style="float:left;">省<span style="color:red">*</span>：</span><div id="PROVINCE" multiples="true" type="select" class="ui-select divselect" isvalid="yes" checkexpession="NotNull" style="float: left;width: 50%;"></div></div>';
                _html += '<div class="tiaoj"><span class="spans" style="float:left;">市<span style="color:red">*</span>：</span><div id="CITY" type="select" multiples="true" class="ui-select divselect" isvalid="yes" checkexpession="NotNull" style="float: left;width: 50%;"></div></div>';
                _html += '<div class="tiaoj"><span class="spans" style="float:left;">县(区)<span style="color:red">*</span>：</span><div id="COUNTY" type="select" multiples="true" class="ui-select divselect" isvalid="yes" checkexpession="NotNull" style="float: left;width: 50%;"></div></div>';
                if (defaluts.showTown == true)
                    _html += '<div class="tiaoj"><span class="spans" style="float:left;">乡镇<span style="color:red">*</span>：</span><div id="TOWN" type="select" multiples="true" class="ui-select divselect" isvalid="yes" checkexpession="NotNull" style="float: left;width: 50%;"></div></div></div>';
                else
                    _html += '<div class="tiaoj"><span class="spans" style="float:left;display:none;">乡镇：</span><div id="TOWN" multiples="true" type="select" class="ui-select divselect" style="float: left;display:none;"></div></div></div>';
            } else if (defaluts.type == 'Z') {
                _html = '<div style="width:100%">';
                _html += '<div style="width: 100%; height: 40px;"><span class="spans" style="display: inline-block; width: 29%; text-align: center">省：</span><div id="PROVINCE" multiples="true" type="select" class="ui-select" style="display: inline-block; width: 66%"></div></div>';
                _html += '<div style="width: 100%; height: 40px;"><span class="spans" style="display: inline-block; width: 29%; text-align: center">市：</span><div id="CITY" type="select" multiples="true" class="ui-select" style="display: inline-block; width: 66%"></div></div>';
                _html += '<div style="width: 100%; height: 40px;"><span class="spans" style="display: inline-block; width: 29%; text-align: center">县(区)：</span><div id="COUNTY" type="select" multiples="true" class="ui-select" style="display: inline-block; width: 66%"></div></div>';
            } else {
                _html = " <table><tr><td class=\"formTitle\">省</td><td> <div id=\"PROVINCE\" multiples=\"true\" type=\"select\" class=\"ui-select\" style=\"float: left; width: 160px; margin-right: 1px;\"></div></td></tr>" +
                                "<tr><td class=\"formTitle\">市</td><td><div id=\"CITY\" multiples=\"true\" type=\"select\" class=\"ui-select\" style=\"float: left; width: 160px; margin-right: 1px;\"></div></td></tr>" +
                                "<tr><td class=\"formTitle\">区</td><td><div id=\"COUNTY\" multiples=\"true\" type=\"select\" class=\"ui-select\" style=\"float: left; width: 160px; margin-right: 1px;\"></div> </td></tr></table>";
            }
        }
        _district.append(_html);
        var _provinceCommbox = _district.find("#PROVINCE");
        var _cityCommbox = _district.find("#CITY");
        var _countyCommbox = _district.find("#COUNTY");
        var _townCommbox = _district.find("#TOWN");
        //省份
        _provinceCommbox.ComboBoxEx({
            url: contentPath + "/SystemManage/Area/GetProvinceListJson",
            param: { codes: "0", provinceIds: defaluts.provinceId },
            id: "F_AreaCode",
            text: "F_AreaName",
            description: "选择省",
            height: "170px"
        }).bind("change", function () {
            var value = $(this).attr('data-value');
            _cityCommbox[0].innerHTML = "选择市";
            _cityCommbox.attr('data-value', '');
            _countyCommbox[0].innerHTML = "选择县/区";
            _countyCommbox.attr('data-value', '');
            _townCommbox[0].innerHTML = "选择乡/镇";
            _townCommbox.attr('data-value', '');
            djcode = value;
            if (!value) {
                value = "abcdef";
            }
            _cityCommbox.ComboBoxEx({
                url: contentPath + "/SystemManage/Area/GetAllByParentCodes",
                param: { codes: value },
                id: "F_AreaCode",
                text: "F_AreaName",
                description: "选择市",
                height: "170px"
            });
            _countyCommbox.ComboBoxEx({
                url: contentPath + "/SystemManage/Area/GetAllByParentCodes",
                param: { codes: "" },
                id: "F_AreaCode",
                text: "F_AreaName",
                description: "选择县/区",
                height: "170px"
            });
            _townCommbox.ComboBoxEx({
                url: contentPath + "/SystemManage/Area/GetAllByParentCodes",
                param: { codes: "" },
                id: "F_AreaCode",
                text: "F_AreaName",
                description: "选择乡/镇",
                height: "170px"
            });
        });
        if (defaluts.selectProviceId != "") {
            _cityCommbox.ComboBoxEx({
                url: contentPath + "/SystemManage/Area/GetAllByParentCodes",
                param: { codes: defaluts.selectProviceId },
                id: "F_AreaCode",
                text: "F_AreaName",
                description: "选择市",
                height: "170px"
            });
        }
        if (defaluts.selectCityId != "") {
            _countyCommbox.ComboBoxEx({
                url: "../../SystemManage/Area/GetAllByParentCodes",
                param: { codes: defaluts.selectCityId },
                id: "F_AreaCode",
                text: "F_AreaName",
                description: "选择县/区",
                height: "170px"
            });
        }
        if (defaluts.selectCounty != "") {
            _townCommbox.ComboBoxEx({
                url: "../../SystemManage/Area/GetAllByParentCodes",
                param: { codes: defaluts.selectCounty },
                id: "F_AreaCode",
                text: "F_AreaName",
                description: "选择乡/镇",
                height: "170px"
            });
        }
        //城市
        _cityCommbox.ComboBoxEx({
            description: "选择市",
            height: "170px"
        }).bind("change", function () {
            var value = $(this).attr('data-value');
            _countyCommbox[0].innerHTML = "选择县/区";
            _countyCommbox.attr('data-value', '');
            _townCommbox[0].innerHTML = "选择乡/镇";
            _townCommbox.attr('data-value', '');
            djcode = value;
            if (!value) {
                $("#CITY").find(".ui-select-text").text("选择市");
                $("#CITY").find(".ui-select-text").css("color", "#999");
                value = "abcdef";
            }
            _countyCommbox.ComboBoxEx({
                url: "../../SystemManage/Area/GetAllByParentCodes",
                param: { codes: value },
                id: "F_AreaCode",
                text: "F_AreaName",
                description: "选择县/区",
                height: "170px"
            });
            _townCommbox.ComboBoxEx({
                url: "../../SystemManage/Area/GetAllByParentCodes",
                param: { codes: "" },
                id: "F_AreaCode",
                text: "F_AreaName",
                description: "选择乡/镇",
                height: "170px"
            });
            //}
        });
        //县/区
        _countyCommbox.ComboBoxEx({
            description: "选择县/区",
            height: "170px"
        }).bind("change", function () {
            _townCommbox[0].innerHTML = "选择乡/镇";
            _townCommbox.attr('data-value', '');
            var value = $(this).attr('data-value');
            djcode = value;
            if (!value) {
                $("#COUNTY").find(".ui-select-text").text("选择县/区");
                $("#COUNTY").find(".ui-select-text").css("color", "#999");
     
            }
            _townCommbox.ComboBoxEx({
                url: "../../SystemManage/Area/GetAllByParentCodes",
                param: { codes: value },
                id: "F_AreaCode",
                text: "F_AreaName",
                description: "选择乡/镇",
                height: "170px"
            });
        });
        //县/区
        _townCommbox.ComboBoxEx({
            description: "选择乡/镇",
            height: "170px"
        }).bind("change", function () {
            var value = $(this).attr('data-value');
            djcode = value;
            if (!value) {
                $("#TOWN").find(".ui-select-text").text("选择乡/镇");
                $("#TOWN").find(".ui-select-text").css("color", "#999");
     
            }
        });
        _provinceCommbox.comboBoxSetValue(defaluts.selectProviceId);
        _cityCommbox.comboBoxSetValue(defaluts.selectCityId);
        _countyCommbox.comboBoxSetValue(defaluts.selectCounty);
        _townCommbox.comboBoxSetValue(defaluts.selectTown);
        function setDistrictValue(provinceid, cityid, countyid, townid, address) {
            var _province = _district.find("#PROVINCE");
            var _city = _district.find("#CITY");
            var _county = _district.find("#COUNTY");
            var _town = _district.find("#TOWN");
            _province.comboBoxSetValue(provinceid);
            _city.comboBoxSetValue(cityid);
            _county.comboBoxSetValue(countyid);
            _town.comboBoxSetValue(townid);
        }
        function getDistrictValue() {
            var districtInfo = {
                provinceId: "",
                provinceName: "",
                cityId: "",
                cityName: "",
                countyId: "",
                countyName: "",
                townId: "",
                townName: "",
                address: "",
                xzqhcode: ""
            };
            var _province = _district.find("#PROVINCE");
            var _city = _district.find("#CITY");
            var _county = _district.find("#COUNTY");
            districtInfo.provinceId = _province[0].dataset.value;
            districtInfo.provinceName = _province[0].dataset.text;
            districtInfo.cityId = _city[0].dataset.value;
            districtInfo.cityName = _city[0].textContent;
            districtInfo.countyId = _county[0].dataset.value;
            districtInfo.countyName = _county[0].textContent;
            districtInfo.townId = _town[0].dataset.value;
            districtInfo.townName = _town[0].textContent;
            if (districtInfo.provinceId) {
                districtInfo.xzqhcode = districtInfo.provinceId;
            }
            if (districtInfo.cityId) {
                districtInfo.xzqhcode = districtInfo.cityId;
            }
            if (districtInfo.countyId) {
                districtInfo.xzqhcode = districtInfo.countyId;
            }
            if (districtInfo.townId) {
                districtInfo.xzqhcode = districtInfo.townId;
            }
            return districtInfo;
        }
        _district[0].d = {
            setDistrictValue: function (provinceid, cityid, countyid, townid, address) {
                setDistrictValue(provinceid, cityid, countyid, townid, address)
            },
            getDistrictValue: function () {
                return getDistrictValue();
            }
        };
        return _district;
    };
    $.fn.setDistrictValue = function (provinceid, cityid, countyid, townid, address) {
        if (this[0].d) {
            this[0].d.setDistrictValue(provinceid, cityid, countyid, townid, address);
        }
        return null;
    };
    $.fn.getDistrictValue = function () {
        if (this[0].d) {
            return this[0].d.getDistrictValue();
        }
        return null;
    };
})(jQuery);