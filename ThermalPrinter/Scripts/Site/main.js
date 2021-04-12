
/*
* ThermalLabel Client Print Utility
* part of ThermalLabel SDK
* https://www.neodynamic.com/
* Copyright (c) 2018 - Neodynamic SRL
*/
 
$(document).ready(function () {
    if( window.chrome ) {
	  $('body').append('<a id="tlprint"></a>');
	} else {
	  $('<iframe />', {
        name: 'tlprint',
        id: 'tlprint',
        width: '1',
        height: '1',
        style: 'visibility:hidden;position:absolute'
		}).appendTo('body');
	}  
})
 
function printThermalLabel() {
    var webPrintJobUrl = $(location).attr('protocol') + "//" + $(location).attr('host') + "/GetWebPrintJob";
    if( window.chrome ) {
		$('#tlprint').attr('href', 'tlprint:' + webPrintJobUrl);
		var a = $('a#tlprint')[0];
		var evObj = document.createEvent('MouseEvents');
		evObj.initEvent( 'click', true, true );
		a.dispatchEvent(evObj);
	} else { 
		$("#tlprint").attr("src", "tlprint:" + webPrintJobUrl);
	}
}
                            