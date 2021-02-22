(function ($) {
    $.fn.mulDistrictsCtl = function (settings) {
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
                html:""
            };
        $.extend(defaluts, settings);
        var _district = $(this).empty();
        var _html;
        if (defaluts.html) {
            _html = defaluts.html;
        }
        else {
            _html = '<div style="float: left; width: 255px;"><div id="PROVINCE" type="select" multiples class="ui-select" style="float: left; width: 84px; margin-right: 1px;"></div><div id="CITY" type="select" multiples class="ui-select" style="float: left; width: 84px; margin-right: 1px;"></div><div id="COUNTY" type="select" multiples class="ui-select" style="float: left; width: 84px; margin-right: 1px;"></div><div id="TOWN" type="select" multiples class="ui-select" style="float: left; width: 84px; margin-right: 1px;"></div></div> '
        }
        _district.append(_html);
        var _provinceCommbox = _district.find("#PROVINCE");
        var _cityCommbox = _district.find("#CITY");
        var _countyCommbox = _district.find("#COUNTY");
        var _townCommbox = _district.find("#TOWN");
        
        //var _addressText = _district.find("#F_Address");
        //省份
        _provinceCommbox.ComboBoxEx({
            url: "../../SystemManage/Area/GetProvinceListJson",
            param: { codes: "0", provinceIds: defaluts.provinceId },
            id: "F_AreaCode",
            text: "F_AreaName",
            description: "选择省",
            height: "170px"
        }).bind("change", function () {
            var value = $(this).attr('data-value');
            _cityCommbox[0].innerHTML = "选择市";
            _cityCommbox.attr('data-value', '');
            _countyCommbox[0].innerHTML = "选择县";
            _countyCommbox.attr('data-value', '');
            _townCommbox[0].innerHTML = "选择乡(镇)";
            _townCommbox.attr('data-value', '');
            if (!value) {
                value = "abcdef";
            }
            _cityCommbox.ComboBoxEx({
                url: "../../SystemManage/Area/GetAllByParentCodes",
                param: { codes: value },
                id: "F_AreaCode",
                text: "F_AreaName",
                description: "选择市",
                height: "170px"
            });
            _countyCommbox.ComboBoxEx({
                url: "../../SystemManage/Area/GetAllByParentCodes",
                param: { codes: value },
                id: "F_AreaCode",
                text: "F_AreaName",
                description: "选择县",
                height: "170px"
            });
            _townCommbox.ComboBoxEx({
                url: "../../SystemManage/Area/GetAllByParentCodes",
                param: { codes: value },
                id: "F_AreaCode",
                text: "F_AreaName",
                description: "选择乡(镇)",
                height: "170px"
            });
        });
        if (defaluts.selectProviceId!="") {
            _cityCommbox.ComboBoxEx({
                url: "../../SystemManage/Area/GetAllByParentCodes",
                param: { codes: defaluts.selectProviceId },
                id: "F_AreaCode",
                text: "F_AreaName",
                description: "选择市",
                height: "170px"
            });
        }
        //城市
        _cityCommbox.ComboBoxEx({
            description: "选择市",
            height: "170px"
        }).bind("change", function () {
            var value = $(this).attr('data-value');
            _countyCommbox[0].innerHTML = "选择县";
            _countyCommbox.attr('data-value', '');
            _townCommbox[0].innerHTML = "选择乡(镇)";
            _townCommbox.attr('data-value', '');
            if (!value) {
                $("#CITY").find(".ui-select-text").text("选择市");
                $("#CITY").find(".ui-select-text").css("color", "#999");
                value = "abcdef";
            }
            //if (value) {
                _countyCommbox.ComboBoxEx({
                    url: "../../SystemManage/Area/GetAllByParentCodes",
                    param: { codes: value },
                    id: "F_AreaCode",
                    text: "F_AreaName",
                    description: "选择县",
                    height: "170px"
                });
                _townCommbox.ComboBoxEx({
                    url: "../../SystemManage/Area/GetAllByParentCodes",
                    param: { codes: value },
                    id: "F_AreaCode",
                    text: "F_AreaName",
                    description: "选择乡(镇)",
                    height: "170px"
                });
            //}
        });
        //县/区
        _countyCommbox.ComboBoxEx({
            description: "选择县",
            height: "170px"
        }).bind("change", function () {
            var value = $(this).attr('data-value');
            _townCommbox[0].innerHTML = "选择乡(镇)";
            _townCommbox.attr('data-value', '');
            if (!value) {
                $("#COUNTY").find(".ui-select-text").text("选择县");
                $("#COUNTY").find(".ui-select-text").css("color", "#999");
            }
            _townCommbox.ComboBoxEx({
                url: "../../SystemManage/Area/GetAllByParentCodes",
                param: { codes: value },
                id: "F_AreaCode",
                text: "F_AreaName",
                description: "选择乡(镇)",
                height: "170px"
            });
        });
        //乡
        _townCommbox.ComboBoxEx({
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
        //_addressText.val(defaluts.address);
        function setDistrictValue(provinceid,  cityid, countyid, twonId, address)
        {
            var _province = _district.find("#PROVINCE");
            var _city = _district.find("#CITY");
            var _county = _district.find("#COUNTY");
            var _twon = _district.find("#TWON");
            
            //var _address = _district.find("#F_Address");
            _province.comboBoxSetValue(provinceid);
            _city.comboBoxSetValue(cityid);
            _county.comboBoxSetValue(countyid);
            _twon.comboBoxSetValue(twonId);
           
            //_address.val(address);
        }
        function getDistrictValue() {
            var districtInfo = {
                provinceId: "",
              
                cityId: "",
                cityName: "",
                countyId: "",
                countyName: "",
                twonId: "",
                twonName:"",
                address: ""
            };
            var _province = _district.find("#PROVINCE");
            var _city = _district.find("#CITY");
            var _county = _district.find("#COUNTY");
            var _twon = _district.find("#TWON");
            districtInfo.provinceId = _province[0].dataset.value;
            districtInfo.provinceName = _province[0].dataset.text;
            districtInfo.cityId = _city[0].dataset.value;
            districtInfo.cityName = _city[0].textContent;
            districtInfo.countyId = _county[0].dataset.value;
            districtInfo.countyName = _county[0].textContent;
            districtInfo.twonId = _twon[0].dataset.value;
            districtInfo.twonName = _twon[0].textContent;
            //districtInfo.address = _district.find("#F_Address").val();
            return districtInfo;
        }
        _district[0].d = {
            setDistrictValue: function (provinceid, cityid, countyid,twonId, address) {
                setDistrictValue(provinceid, cityid, countyid,twonId, address)
            },
            getDistrictValue: function () {
                return getDistrictValue();
            }
        };
        return _district;
    };
    $.fn.setDistrictValue = function (provinceid,cityid, countyid, twonId, address) {
        if (this[0].d) {
            this[0].d.setDistrictValue(provinceid, cityid, countyid,twonId, address);
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