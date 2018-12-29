using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace B4.EE.DeBisschopS
{
    public static class Statics
    {
        public static readonly ObservableCollection<string> ImageNamesList =
            new ObservableCollection<string>()
            {
                "apple.png",
                "bread_egg.png",
                "carrot.png",
                "cheeseburger.png",
                "cherries.png",
                "cookie.png",
                "donut.png",
                "french_fries.png",
                "fried_chicken.png",
                "grapes.png",
                "hotdog.png",
                "ice_cupcake.png",
                "lemon.png",
                "macaron_cookies.png",
                "pear.png",
                "pizza.png",
                "popcorn.png",
                "sliced_pizza.png",
                "soft_ice_cream.png",
                "strawberry_magnum.png",
                "vanilla_cupcake.png"
            };

        public static readonly ObservableCollection<string> CurrencyOptions =
            new ObservableCollection<string>()
            {
                "Tokens",
                "Euro",
                "Dollar",
                "Coins",
                "Yen",
                "Pound",
                "Boxes",
                "Items"
            };
    }
}
