function getBotResponse(input) {
    //rock paper scissors
    if (input == "rock") {
        return "paper";
    } else if (input == "paper") {
        return "scissors";
    } else if (input == "scissors") {
        return "rock";
    }

    // Simple responses
    if (input == "hello") {
        return "Hello there!";
    } else if (input == "goodbye" || input == "good bye" || input == "bye"){
        return "Talk to you later!";
    } else if (input == "what is your name?" || input == "what is your name" || input == "who are you" || input == "who are you ?") {
        return "I am chatbot";
    }
    else if (input == "how are you ?" || input == "how are you") {
        return "I am fine thankyou what about";
    }
    else if (input == "is school care is best website" || input == "is school care is best website ?") {
        return "well can't say because its still growing"
    }
    else if (input == "do you know where we can find services") {
        return "just go to the academics in nav bar or you can scroll down to services section";

}
    else if (input == "well done" || input == "keep it up") {
        return "thannks for the appreciation it motivates our team to do hard work.";
    }
    else if (input == "thanks" || input == "thankyou") {
        return "hope you like our services feel free to ask me any time you want";
    }

    else if (input == "do you know where we can get fee related information") {
        return "Please click on academics section in the nav bar and then fee structure";
    }
    else if (input == "good morning" || input == "Good Morning" || input == "Goodmorning" || input == "goodmorning")
    {
        return "Good Morning Sir How are you ?";
    }
    else if (input == "What do you think about this website" || input == "what do you think about this website")
    {
        return "Well its awesome website for school and happy that i am a part of it :)";
    }
    else if (input == "who developed you ?" || input == "who developed you " || input == "who made you ?" || input == "who is your creator ?" || input == "Who developed you" || input == "who developed you" || input == "who made you" || input == "who is your creator") {
        return "Well i was developed by Ashutosh Ranjan a software development intern at Dotplus Technologies but i am still in developing phase and still not ready to help users :(";
    }
    else {
        return "Try asking something else! and i am really sorry for the problem";
    }
}
