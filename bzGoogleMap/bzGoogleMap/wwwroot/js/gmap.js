function initialize(latitude, longitude) {
    //var latlng = new google.maps.LatLng(40.716948, -74.003563);
    var latlng = new google.maps.LatLng(latitude, longitude);

    var position = {
        lat: latitude,
        lng: longitude
    };

    var options = {
        zoom: 14, center: latlng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    var map = new google.maps.Map(document.getElementById("map"), options);

    var marker = new google.maps.Marker({
        position: position,
        map: map
    });
}