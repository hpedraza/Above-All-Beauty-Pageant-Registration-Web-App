function initialize() {

    var myLatLng = {lat: 26.2505304, lng:-98.15763859999998};

    var mapUpcoming = {
        center: myLatLng,
        zoom: 15,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };

    var map = new google.maps.Map(document.getElementById('mapUpcoming'), mapUpcoming);

    var aboveAllHeadquartersMarker = new google.maps.Marker({
        position: myLatLng,
        map: map,
        Title: 'Above All Beauty Pageant Headquarters'
    });


}

google.maps.event.addDomListener(window, 'load', initialize);