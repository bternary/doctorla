importScripts("https://www.gstatic.com/firebasejs/7.12.0/firebase-app.js");
importScripts("https://www.gstatic.com/firebasejs/7.12.0/firebase-messaging.js");

  var firebaseConfig = {
    apiKey: "AIzaSyCimPZhw6KMTluNh_XsKHDgOVeJoXU2bQs",
    authDomain: "onlinesaglikcim-bd3ec.firebaseapp.com",
    databaseURL: "https://onlinesaglikcim-bd3ec.firebaseio.com",
    projectId: "onlinesaglikcim-bd3ec",
    storageBucket: "onlinesaglikcim-bd3ec.appspot.com",
    messagingSenderId: "696486224235",
    appId: "1:696486224235:web:d5bdb68c2104670f1e6c2e",
    measurementId: "G-9WYCQ6W7N7"
};

//var firebaseConfig = {
//    apiKey: "AIzaSyBXNzRDrAeCdgojS--_d14ClqL2VBlKgps",
//    authDomain: "doctorla-6c3c5.firebaseapp.com",
//    projectId: "doctorla-6c3c5",
//    storageBucket: "doctorla-6c3c5.appspot.com",
//    messagingSenderId: "266414992403",
//    appId: "1:266414992403:web:46ce627feca44c7a2263e6"
//};

var defaultProject = firebase.initializeApp(firebaseConfig);

var messaging = firebase.messaging();

// Burası arkaplanda çalışan kısım aynı kodlar iki tarafta da var burayla bağımsız diğeri onmessage da  bak aynısı içerik
messaging.setBackgroundMessageHandler(function(payload){
   var notificationTitle = payload.data.title;
   var notificationOptions = {
       body: payload.data.body,
       icon: payload.data.icon,
       click_action:payload.data.click_action
   };
   return self.registration.showNotification(notificationTitle,notificationOptions);
});