(function ($) {
    $.fn.districtsCtl = function (settings) {
        var _coordSys = "";
        var _isProjectiveGeo = "";
        //默认选项
        var defaluts =
            {
                provinceId: "",//初始化省的个数
                selectProviceId: "",//选中省
                selectCityId: "",//选中市
                selectCounty: "",//选中县
                selectTown: "",//选中乡
                html: "",
                showTown: true,
                callBack: null//回调函数
            };
        $.extend(defaluts, settings);
        var _district = $(this).empty();
        var _html;
        if (defaluts.html) {
            _html = defaluts.html;
        }
        else {
            //_html = '<div style="float: left; width: 255px;"><div id="PROVINCE" type="select" class="ui-select" style="float: left; width: 84px; margin-right: 1px;"></div><div id="CITY" type="select" class="ui-select" style="float: left; width: 84px; margin-right: 1px;"></div><div id="COUNTY" type="select" class="ui-select" style="float: left; width: 84px; margin-right: 1px;"></div><div id="TOWN" type="select" class="ui-select" style="float: left; width: 84px; margin-right: 1px;"></div></div>';
            _html = '<div style="float: left;width:100%;align-items: center;flex-wrap: nowrap;">';
            _html += '<div class="tiaoj"><span class="spans" style="float:left;">省<span style="color:red">*</span>：</span><div id="PROVINCE" type="select" class="ui-select divselect" isvalid="yes" checkexpession="NotNull" style="float: left;width: 50%;"></div></div>';
            _html += '<div class="tiaoj"><span class="spans" style="float:left;">市<span style="color:red">*</span>：</span><div id="CITY" type="select"  class="ui-select divselect" isvalid="yes" checkexpession="NotNull" style="float: left;width: 50%;"></div></div>';
            _html += '<div class="tiaoj"><span class="spans" style="float:left;">县(区)<span style="color:red">*</span>：</span><div id="COUNTY" type="select"  class="ui-select divselect" isvalid="yes" checkexpession="NotNull" style="float: left;width: 50%;"></div></div>';
            if (defaluts.showTown == true)
                _html += '<div class="tiaoj"><span class="spans" style="float:left;">乡镇<span style="color:red">*</span>：</span><div id="TOWN" type="select"  class="ui-select divselect" isvalid="yes" checkexpession="NotNull" style="float: left;width: 50%;"></div></div></div>';
            else
                _html += '<div class="tiaoj"><span class="spans" style="float:left;display:none;">乡镇：</span><div id="TOWN"  type="select" class="ui-select divselect" style="float: left;display:none;"></div></div></div>';
        }
        _district.append(_html);
        var _provinceCommbox = _district.find("#PROVINCE");
        var _cityCommbox = _district.find("#CITY");
        var _countyCommbox = _district.find("#COUNTY");
        var _townCommbox = _district.find("#TOWN");
        //var _addressText = _district.find("#F_Address");
        //省份
        _provinceCommbox.ComboBox({
            url: "../../SystemManage/Area/GetProvinceListJson",
            param: { parentId: "0", provinceIds: defaluts.provinceId },
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
            _townCommbox[0].innerHTML = "选择乡(镇)";
            _townCommbox.attr('data-value', '');
            _cityCommbox.ComboBox({
                url: "../../SystemManage/Area/GetAllByParentCodes",
                param: { codes: value },
                id: "F_AreaCode",
                text: "F_AreaName",
                description: "选择市",
                height: "170px"
            });
            _countyCommbox.ComboBox({
                url: "../../SystemManage/Area/GetAllByParentCodes",
                param: { codes: "" },
                id: "F_AreaCode",
                text: "F_AreaName",
                description: "选择县/区",
                height: "170px"
            });
            _townCommbox.ComboBox({
                url: "../../SystemManage/Area/GetAllByParentCodes",
                param: { codes: "" },
                id: "F_AreaCode",
                text: "F_AreaName",
                description: "选择乡(镇)",
                height: "170px"
            });
            if (defaluts.callBack && typeof (eval(defaluts.callBack)) == "function") {
                defaluts.callBack(value);
            }
        });
        //城市
        _cityCommbox.ComboBox({
            description: "选择市",
            height: "170px"
        }).bind("change", function () {
            var value = $(this).attr('data-value');
            _countyCommbox[0].innerHTML = "选择县/区";
            _countyCommbox.attr('data-value', '');
            _townCommbox[0].innerHTML = "选择乡(镇)";
            _townCommbox.attr('data-value', '');
            _countyCommbox.ComboBox({
                url: "../../SystemManage/Area/GetAllByParentCodes",
                param: { codes: value },
                id: "F_AreaCode",
                text: "F_AreaName",
                description: "选择县/区",
                height: "170px"
            });
            _townCommbox.ComboBox({
                url: "../../SystemManage/Area/GetAllByParentCodes",
                param: { codes: "" },
                id: "F_AreaCode",
                text: "F_AreaName",
                description: "选择乡(镇)",
                height: "170px"
            });
            if (defaluts.callBack && typeof (eval(defaluts.callBack)) == "function") {
                defaluts.callBack(value);
            }
        });
        //县/区
        _countyCommbox.ComboBox({
            description: "选择县/区",
            height: "170px"
        }).bind("change", function () {
            var value = $(this).attr('data-value');
            _townCommbox[0].innerHTML = "选择乡(镇)";
            _townCommbox.attr('data-value', '');
            if (!value) {
                $("#COUNTY").find(".ui-select-text").text("选择县");
                $("#COUNTY").find(".ui-select-text").css("color", "#999");
            }
            _townCommbox.ComboBox({
                url: "../../SystemManage/Area/GetAllByParentCodes",
                param: { codes: value },
                id: "F_AreaCode",
                text: "F_AreaName",
                description: "选择乡(镇)",
                height: "170px"
            });
            if (defaluts.callBack && typeof (eval(defaluts.callBack)) == "function") {
                defaluts.callBack(value);
            }
        });
        //乡
        _townCommbox.ComboBox({
            description: "选择乡(镇)",
            height: "170px"
        }).bind("change", function () {
            var value = $(this).attr('data-value');
            if (!value) {
                $("#TWON").find(".ui-select-text").text("选择乡(镇)");
                $("#TWON").find(".ui-select-text").css("color", "#999");
            }
        });
        _provinceCommbox.comboBoxSetValue(defaluts.selectProviceId);
        _cityCommbox.comboBoxSetValue(defaluts.selectCityId);
        _countyCommbox.comboBoxSetValue(defaluts.selectCounty);
        _townCommbox.comboBoxSetValue(defaluts.selectTown);
        function setDistrictValue(provinceid, cityid, countyid, address) {
            var _province = _district.find("#PROVINCE");
            var _city = _district.find("#CITY");
            var _county = _district.find("#COUNTY");
            var _twon = _district.find("#TWON");
            _province.comboBoxSetValue(provinceid);
            _city.comboBoxSetValue(cityid);
            _county.comboBoxSetValue(countyid);
             _twon.comboBoxSetValue(twonId);
        }
        function setDistrictCode(code) {
            if (code.length == 9) {
                _provinceCommbox.comboBoxSetValue(code.substr(0, 2) + "0000");
                _cityCommbox.comboBoxSetValue(code.substr(0, 4) + "00");
                _countyCommbox.comboBoxSetValue(code.substr(0, 6));
                _townCommbox.comboBoxSetValue(code);
            }
            else if (code.length == 6) {
                if (code.substr(2, 4) == "0000") {
                    _provinceCommbox.comboBoxSetValue(code);

                }
                else if (code.substr(4, 2) == "00") {
                    _provinceCommbox.comboBoxSetValue(code.substr(0, 2) + "0000");
                    _cityCommbox.comboBoxSetValue(code);
                }
                else {
                    _provinceCommbox.comboBoxSetValue(code.substr(0, 2) + "0000");
                    _cityCommbox.comboBoxSetValue(code.substr(0, 4) + "00");
                    _countyCommbox.comboBoxSetValue(code);
                }
            }
        }
        function getDistrictValue() {
            var districtInfo = {
                provinceId: "",
                provinceName: "",
                cityId: "",
                cityName: "",
                countyId: "",
                countyName: "",
                address: ""
            };
            var _province = _district.find("#PROVINCE");
            var _city = _district.find("#CITY");
            var _county = _district.find("#COUNTY");
            var _twon = _district.find("#TWON");
            districtInfo.provinceId = _province[0].dataset.value;
            districtInfo.provinceName = _province[0].dataset.text;
            districtInfo.cityId = _city[0].dataset.value;
            districtInfo.cityName = _city[0].dataset.text;
            districtInfo.countyId = _county[0].dataset.value;
            districtInfo.countyName = _county[0].dataset.text;
            districtInfo.twonId = _twon[0].dataset.value;
            districtInfo.twonName = _twon[0].textContent;
            //districtInfo.address = _district.find("#F_Address").val();
            return districtInfo;
        }
        _district[0].d = {
            setDistrictValue: function (provinceid, cityid, countyid, address) {
                setDistrictValue(provinceid, cityid, countyid, address)
            },
            getDistrictValue: function () {
                return getDistrictValue();
            },
            setDistrictCode: function (code) {
                return setDistrictCode(code);
            }
        };
        return _district;
    };
    $.fn.setDistrictValue = function (provinceid, cityid, countyid, address) {
        if (this[0].d) {
            this[0].d.setDistrictValue(provinceid, cityid, countyid, address);
        }
        return null;
    };
    $.fn.getDistrictValue = function () {
        if (this[0].d) {
            return this[0].d.getDistrictValue();
        }
        return null;
    };
    $.fn.setDistrictCode = function (code) {
        if (this[0].d) {
            return this[0].d.setDistrictCode(code);
        }
        return null;
    };
})(jQuery);