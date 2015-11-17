dog_site = {};

dog_site.getVisible = function () {
    document.getElementById('g_god_div').style.visibility = 'visible';
    document.getElementById('dog_music').play();
}

dog_site.init = function () {
    dog_site.dog = document.getElementById("dog");
    dog_site.pet_count = document.getElementById("pet_count");
    dog_site.pets = 0;
    dog.addEventListener("mousedown", dog_site.mousedown);
    dog.addEventListener("mouseup", dog_site.mouseup);
    dog_site.loop();
}

dog_site.mousedown = function () {
    if (dog_site.pets > 50)
        dog_site.dog.src = "/Content/dog_l.png";
    else
        dog_site.dog.src = "/Content/dog_happy_l.png";
    dog_site.pets++;
    if (dog_site.pets < 10) {
        dog_site.dog.className += " clicked";
    }
    dog_site.pet_count.className += " clicked";
}

dog_site.mouseup = function () {
    if (dog_site.pets > 50)
        dog_site.dog.src = "/Content/dog_happy_l.png";
    else
        dog_site.dog.src = "/Content/dog_l.png";
    dog_site.dog.className -= " clicked";
    dog_site.pet_count.className -= " clicked";
}

dog_site.loop = function () {
    dog_site.pet_count.innerHTML = dog_site.pets;
    setTimeout(dog_site.loop, 1000 / 60);

    if (dog_site.pets > 5) {
        dog_site.dog.style.animation = "spin " + 500 / dog_site.pets + "s linear infinite";
    }
}

window.onload = function () {
    dog_site.init();
}