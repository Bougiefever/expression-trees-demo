using System.ComponentModel;
using System.Linq;
using System.Reflection;
using ExpressionTreesDemo.Data.Query;

namespace ExpressionTreesDemo.Data.V2
{
  public static class DemoHelper
  {
    private static Category[] _categories;
    private static Product[] _products;

    public static Category[] Categories
    {
      get
      {
        if (_categories == null)
          _categories = new[]
                        {
                          new Category {Id = 100, CategoryType = CategoryType.Car},
                          new Category {Id = 101, CategoryType = CategoryType.Pet},
                          new Category {Id = 102, CategoryType = CategoryType.Cosmetics},
                          new Category {Id = 103, CategoryType = CategoryType.Food},
                        };
        return _categories;
      }
    }

    public static Product[] Products
    {
      get
      {
        if (_products == null)
          _products = new[]
                      {
                        new Product
                        {
                          Id = 11,
                          Category = Categories.First(c => c.Id == 100),
                          Name = "Body Wash",
                          Description =
                            @"This concentrated premium cleaner produces a high foam to deep clean your vehicle. The gentle foam is safe for all vehicle finishes. Just one ounce will clean the entire exterior of your vehicle. If you want a clean vehicle without water spots, our Body Wash will not disappoint when used properly. Dark Teal"
                        },
                        new Product
                        {
                          Id = 12,
                          Category = Categories.First(c => c.Id == 100),
                          Name = "Alumination",
                          Description =
                            @"This is a powerful yet easy to use aluminum polish with a polymer protectant. This exciting new product works great on all metal finishes. Not only does it clean and remove oxidation, it will leave a show shine finish that will brighten anyone’s day. Lime Green"
                        },
                        new Product
                        {
                          Id = 13,
                          Category = Categories.First(c => c.Id == 100),
                          Name = "Body Solv",
                          Description =
                            @"This product works hard for you so that you won’t have to. Removes those tough nasties such as bugs, tar, adhesive, grease and sap. The natural orange oil penetrates and quickly loosens the most difficult to remove substances. Just saturate a clean rag with Auto Cosmetics Body Solv, apply the saturated rag to the soiled surface and rub. Use this product almost anywhere where you need to remove grease, adhesive and other tough sticky messes. Bright Orange"
                        },
                        new Product
                        {
                          Id = 14,
                          Category = Categories.First(c => c.Id == 100),
                          Name = "Body Wax",
                          Description =
                            @"For the ultimate in protection and shine, our Body Wax is an easy to use high grade wax, formulated with pure imported carnauba. This easy on, easy off formula is safe for all vehicle finishes and will provide a long lasting wet look that will leave others dull with envy. Cream"
                        },
                        new Product
                        {
                          Id = 15,
                          Category = Categories.First(c => c.Id == 100),
                          Name = "Clean Wheels",
                          Description =
                            "Made especially for factory clear-coated wheels, Clean Wheels clings and penetrates to remove brake dust and dirt. Just spray on and let Clean Wheels do the job. Rinse with water. Creamy Yellow"
                        },
                        new Product
                        {
                          Id = 10,
                          Category = Categories.First(c => c.Id == 100),
                          Name = "Sparkleberry Dressing",
                          Description =
                            "This strawberry scented tire and interior dressing leaves tires with that long lasting 'wet look'. Made with pure strawberry extract. Also protects vinyl and rubber areas inside and out.Very easy to use. For tires: Just spray and walk away. For interiors: Spray onto applicator and wipe on. Red"
                        },
                        new Product
                        {
                          Id = 16,
                          Category = Categories.First(c => c.Id == 100),
                          Name = "Magic Melon Dressing",
                          Description =
                            "This melon scented tire and interior dressing leaves tires with that long lasting 'wet look'. Made with all-natural melon extracts. Also protects vinyl and rubber areas inside and out.Very easy to use. For tires: Just spray and walk away. For interiors: spray onto applicator and wipe on. Light Green"
                        },
                        new Product
                        {
                          Id = 17,
                          Category = Categories.First(c => c.Id == 100),
                          Name = "Maxi-Clean",
                          Description =
                            "This ultra concentrated cleaner is perfect for upholstery and carpets. Can be used full strength for extra tough jobs, or diluted 10:1 for a great general cleaner/degreaser. Can be used to clean upholstery, vinyl, wheels, tires, grills, patio furniture, garden equipment and more. Green"
                        },
                        new Product
                        {
                          Id = 18,
                          Category = Categories.First(c => c.Id == 100),
                          Name = "Bubble Gum Car Air Freshener",
                          Description =
                            "Bubble gum car air freshener is a fresh smelling bubble gum car scent for your automobile's interior. this is a a unique car air freshener for individuals who like to smell different scents. bubble gum car air freshener can be used in the interior of new or used cars. if you like the smell of bubble gum this car air freshener is for you. Pink"
                        },

                        new Product
                        {
                          Id = 21,
                          Category = Categories.First(c => c.Id == 101),
                          Name = "Earths Balance Odor Neutralizer",
                          Description =
                            "G-Whiz for Dogs works internally to help prevent lawn burns and odors. This liquid blend of natural ingredients works internally in a pet’s intestinal tract to aid in the digestion of proteins. G-Whiz is safe for pets and reduces the \"burn effect\" of dog urine. Studies have shown G-Whiz to be 400% more effective than parsley seed extract, known for its ability to eliminate bad breath and foul odors in pets. It’s easy to use and comes with a convenient pump that assures a trouble free way to add it to your pet’s food or water. Recommended by veterinarians, it is clinically proven to control waste odors, breath and gas odors. Bright Blue"
                        },
                        new Product
                        {
                          Id = 22,
                          Category = Categories.First(c => c.Id == 101),
                          Name = "NaturVet Yellow to Green Lawn Spray",
                          Description =
                            "NaturVet Yellow to Green Lawn Spray is formulated to make yellow spots from pet urine instantly green.  In just minutes, your yellow spots can be restored to green grass color, and it won't wash away."
                        },
                        new Product
                        {
                          Id = 23,
                          Category = Categories.First(c => c.Id == 101),
                          Name = "Earths Balance Avian Solution Daily Bird Bath",
                          Description =
                            "100% natural cleansing and healing formula keep your bird's feathers clean, fresh and vibrant. The main ingredient is electrolyzed oxidizing water, which attracts oxygen ions to accelerate the healing of dry skin and even small wounds. Multi-purpose: soothes sunburns, inscect bites, neutralizes odors in cages and water bowls. Dark Blue"
                        },
                        new Product
                        {
                          Id = 24,
                          Category = Categories.First(c => c.Id == 101),
                          Name = "8in1 Grape Mineral Treat for Small Birds",
                          Description =
                            "The 8in1 Grape Mineral Treat for Small Birds will help your pets develop a strong composition. This supplement is high in calcium, iodine, and phosphorous. These ingredients help maintain a healthy bone and cartilage formation. These treats have a delicious fruity flavor which encourages pecking activity and entertainment. The treats are also shapes like grapes, and are great for keeping your birds' beaks trimmed. Purple"
                        },
                        new Product
                        {
                          Id = 25,
                          Category = Categories.First(c => c.Id == 101),
                          Name = "Brightwell Aquatics Neo Marine Reef Salt",
                          Description =
                            "The chemical composition of seawater has remained relatively constant for over the past hundred-million years. Corals and reefs have thrived off these natural conditions of the water for millions of years. With that said, it is common sense to replicate the most important aspects of the natural chemical composition of seawater as closely as possibly to properly care for delicate marine creatures in captivity. The single most important contributor to success with a marine aquarium is maintaining water parameters within tolerable ranges. No amount of lighting and filtration can compensate for water that is lacking the essential elements required for survival by marine organisms. Brightwell has done this with the Neo Marine Reef Salt. It provides all major elements to ensure your marine water is safe and nourishing for your marine life. Brown"
                        },
                        new Product
                        {
                          Id = 26,
                          Category = Categories.First(c => c.Id == 101),
                          Name = "Marshall Goodbye Odor for Ferrets",
                          Description =
                            "Marshall's Bi-Odor Waste Deodorizer is a safe and all-natural food supplement that will allow you to say good-bye to litter pan odor forever! Its a revolutionary product that eliminates stool, urine, and body odors internally. Just a few pumps of Bi-Odor in your ferret’s food or water daily, and in as little as one week, you’ll notice your ferret’s waste will no longer smell! Yellow "
                        },
                        new Product
                        {
                          Id = 27,
                          Category = Categories.First(c => c.Id == 101),
                          Name = "GoodBye Odor Small Animal Waste Deodorizer",
                          Description =
                            "Marshalls Goodbye Odor Waste Deodorizer is a safe and all-natural food supplement that will allow you to say good-bye to litter pan odor forever! Its a revolutionary product that eliminates stool, urine, and body odors internally. Just a few pumps in your pet's food or water daily, and in as little as one week, you’ll notice the waste will no longer smell! Yellow"
                        },
                        new Product
                        {
                          Id = 28,
                          Category = Categories.First(c => c.Id == 101),
                          Name = "Advantage Treatment Flea Tick Cat/Kitten Shampoo",
                          Description =
                            "Advantage Treatment Flea/Tick Cat/Kitten Shampoo is specifically formulated for cats and kittens over 12 weeks old.  It works on contact to kill fleas and ticks.  The unscented formula is ideal for pets as well as pet owners that are sensitive to fragrance. Clear liquic"
                        },
                        new Product
                        {
                          Id = 29,
                          Category = Categories.First(c => c.Id == 101),
                          Name = "Natural Dog Gum Disease Treatment",
                          Description =
                            "Myrrh is a great way of eliminating your pet's gum disease through a natural method. This herb is available in distilled oil form, and this is the type of myrrh that is most effective at reducing the pain and swelling associated with canine gum disease. Place a cotton swab or a Q-tip into the distilled myrrh solution and swab the inside of your pet's mouth with it, focusing particularly on the gums. This will help to ease his pain. Gray"
                        },
                        new Product
                        {
                          Id = 30,
                          Category = Categories.First(c => c.Id == 101),
                          Name = "Bissell ewww Cat Stain & Odor Cleaner",
                          Description =
                            "Pawsitively Clean Ewww Enzymatic Cat Stain and Odor Remover by Bissell Something smells bad, really bad. But enzymes are oh, so good. Tackle your pet's worst accidents with ewww pet stain and odor remover. The enzyme power permanently removes organic stains from urine, feces and other accidents. Features: · Powerful enzyme-action tackles deep down stains and odors · Fast acting cleaning and deodorizing agents start working immediately · Permanently removes organic stains from urine, feces and other accidents · Safe for use on carpets, upholstery, pet beds, litter boxes or any water-safe surface. Clear."
                        },
                        new Product
                        {
                          Id = 20,
                          Category = Categories.First(c => c.Id == 101),
                          Name = "Nature's Miracle Stain & Odor Remover -- Pet Odor Cleaner",
                          Description =
                            "Pet stains and odors are a part of every pet parent’s life, but they don’t have to ruin your day or your floors! Nature’s Miracle Stain & Odor Remover is an advanced formula that works to eliminate pet stains and odors rather than masking them. With a handy bottle of this pet stain and odor destroyer, you can spend more time cuddling with your pet and less time worrying about messes. Clear."
                        },

                        new Product
                        {
                          Id = 31,
                          Category = Categories.First(c => c.Id == 102),
                          Name = "Almond oil sweet ",
                          Description =
                            "All natural sweet almond oil is used as a moisturizer and as a carrier oil in aromatherapy. It is an effective emollient, softening and smoothing the skin. It is one of the most commonly used carrier oils because it does not leave a greasy residue. It is obtained from the dried kernel of the almond tree. The oil from the almond nut is rich in vitamin A and a superb natural moisturiser. Sweet almond oil is very beneficial for dry and mature skin, providing necessary moisture. Clear"
                        },
                        new Product
                        {
                          Id = 32,
                          Category = Categories.First(c => c.Id == 102),
                          Name = "Bay leaf oil (Laurus Nobilis)",
                          Description =
                            "The all-natural bay tree is an evergreen, reaching 7.5 to 9 meters (25- 30 feet), sprouting thick glossy leaves. When in season the Bay produces yellow tinged flowers and rich black berries. Fresh bay leaves are very strongly aromatic but also quite bitter. An essential oil is a concentrated, aromatic, volatile liquid composed of small oil-like molecules. The bay oil has a fresh-spicy top note, with a rich sweet-balsamic undertone, faintly sweet-balsamic dry out. Oil is relaxing and warming. Dark green"
                        },
                        new Product
                        {
                          Id = 33,
                          Category = Categories.First(c => c.Id == 102),
                          Name = "Lavender Oil, Lavender Flowers",
                          Description =
                            "Lavender oil can be used in cosmetic bases to provide natural perfume and aromatherapy benefits. It is used extensively to perfume products in the soap and cleaning industries The pure aromatic oil is used in toilet water, cologne, and perfume. Lavender also is used in bath products and stimulating, cleansing facial steams. It is said to repel mosquitoes. It can flavor vinegars and jellies. Decorative uses include floral arrangements, wreaths, and wands. Lavender is said to have some medicinal qualities. Light purple"
                        },
                        new Product
                        {
                          Id = 34,
                          Category = Categories.First(c => c.Id == 102),
                          Name = "Camphor Wood, Formosan wood",
                          Description =
                            "All natural camphor tree distillate is a common preservative in cosmetics, hair care products, emollients, and astringents. Another use: It leaves the skin feeling cool and fresh. Oil distilled from the wood, roots and branches of an evergreen tree native to India used to treat acne, inflammation, oily conditions, spots. Evergreen tree about 15m.tall. Truck bark thick and grooved. Leaves altemate, coriaceous, long-petiolate, shining on the upper side, 3-neverd at the base. Inflorescence in axillary panicle, shorter than the leaf; flowers small, greenish- yellow. Berry globose, blck when ripe. The stem wood and leaves contain an essential oil consisting of camphor, D-a-pinene, cineol, terpineol, caryophylin safrole, limonene, Phellandrene, carvacol, comphorene and azulene. Black"
                        },
                        new Product
                        {
                          Id = 35,
                          Category = Categories.First(c => c.Id == 102),
                          Name = "Bees Wax",
                          Description =
                            "Pure, use in lip gloss, lotions & creams; for sealing corked bottles. Solid at room temperature.  Bees Wax contains free acids, esters and other natural components, that give the wax special characteristics, such as emulsifying properties, plasticity, compatibility with other natural products and a pleasant scent. These properties make the Bees Wax a very suitable product for cosmetic formulations like facial and corporal creams and lip balms. The yellow and white Bees wax that Multiceras offers fulfill the USP requirements.  Bees wax is the primary bee product Cross A Ranch uses at this point because it works on human skin because of its compatibility and because it helps us emulsify our creams and lotions. A lot medicinal literature concerning the use of bees wax for its potential health benefits for humans, has generally been disregarded by the medical profession in Western societies. However, bees wax and products of the bee hive have been used in local, traditional medicine for centuries. In the UK doctors have had success in treating hay fever patients with bees wax. hough U.S. exports of bees wax have increased somewhat, the source of the demand remains elusive. Bees wax is commonly known as White Wax (cera Alba) or Yellow Wax (cera Flava). This wax is secreted by the bees when constructing their honeycombs. Bees Wax is obtained by melting and filtering the honeycombs to get a clean wax. This crude wax has a color between coffee and yellow, depending on the type of flowers in the area where the bees live. Light Brown "
                        },
                        new Product
                        {
                          Id = 36,
                          Category = Categories.First(c => c.Id == 102),
                          Name = "Bentonite, Bentonite Clay, Fullers Clay",
                          Description =
                            "Bentonite or Fullers Clay is a naturally occurring sedimentary clay composed mainly of alumina, silica, iron oxides, lime, magnesia, and water, in extremely variable proportions. It has the incredible ability to remove oils and impurities from the skin and produces a lightening effect on the outer epidermal layer. This is why we have seen several products marketed as \"facial bleach\" or \"skin bleaching\". It comes highly recommended to those with acne problems, blemishes, and people prone to oily skin. It is also a useful base ingredient for facial clay recipes and adds a nice finishing touch to clay products promising to aid its user with their battle against oily skin. Gray"
                        },
                        new Product
                        {
                          Id = 37,
                          Category = Categories.First(c => c.Id == 102),
                          Name = "Centella, Brahmi, Indian Pennywort, Gotu Kala",
                          Description =
                            "Pure natural centella asiatica has been used traditionally in the management of skin disorders. The extract has also been included in anti-aging creams and other topical formulations useful in retarding free radical mediated degenerative changes in the skin. Chemical constituents:  Asiaticoside. madecassoside. brahmoside. bicycloelemene, centelloside. indocentelloside, oxyasiatiocoside, thankuniside. asiatic acid, betulinic acid. centellic acid. madecassic acid. centellose. kaempferol. hydrocotyline. phellandrene, vitamin C, linamarase. triterpenoid trisaccharides. Teal powder "
                        },
                        new Product
                        {
                          Id = 38,
                          Category = Categories.First(c => c.Id == 102),
                          Name = "Xanthan Gum",
                          Description =
                            "Xanthan Gum and Biosaccharide Gum-1 are polysaccharides derived from the fermentation of carbohydrates. Xanthan Gum is derived from glucose or corn syrup, while Biosaccharide Gum-1 is derived from sorbitol. Xanthan Gum and Biosaccharide Gum-1 are used in a wide variety of cosmetics and personal care products including bath products, makeup, skin and hair care products, and toothpaste. Xanthan Gum and Biosaccharide Gum-1 are both very large molecules with average molecular weights of 1,000,000 or more. Xanthan Gum dissolves readily in water with stirring, resulting in highly viscous solutions at low concentrations."
                        },

                        new Product
                        {
                          Id = 41,
                          Category = Categories.First(c => c.Id == 103),
                          Name = "Ascorbic Acid",
                          Description =
                            "(Vitamin C) is used as a vitamin supplement in food and beverages, as a dough conditioning agent as well as an antioxidant in canned and frozen prepared foods. White powder"
                        },
                        new Product
                        {
                          Id = 42,
                          Category = Categories.First(c => c.Id == 103),
                          Name = "Sorbitol",
                          Description =
                            "Multifunctional polyol (polyhydric alcohol) which can be used as a nutritive sugar substitute. Mainly used for its humectant properties in various food products, it also is used in sugarfree confections for crystallization control. Noncarinogenic and approximately 6O% as sweet as sugar Sorbitol is used in dietetic foods as a sugar substitute. Sorbitol is used for example in toothpaste, pet foods, surimi, chewing gum, bakery products and sugarfree candy. Commercial use. White powder"
                        },
                        new Product
                        {
                          Id = 43,
                          Category = Categories.First(c => c.Id == 103),
                          Name = "Gluconic Acid 50%",
                          Description =
                            "An excellent chelating agent in alkaline solutions and is stable even in 1 5% caustic soda. It is mainly used for technical applications, e.g. for surface finishing of metals, in the textile industry for inhibiting precipitates on fibers and removing encrustations. Commercial use. Clear gel"
                        },
                        new Product
                        {
                          Id = 44,
                          Category = Categories.First(c => c.Id == 103),
                          Name = "Citric Acid",
                          Description =
                            "Citric Acid is the most widely used acid and pH control agent in the food industry. Citric acid is characterized by a pleasant tart flavor easy solubility and stability. It is suitable for a wide range of food and industrial applications including beverages, confectionery canned foods and as a basic chemical. Commercial use. White powder"
                        },
                        new Product
                        {
                          Id = 45,
                          Category = Categories.First(c => c.Id == 103),
                          Name = "Potassium Sorbate",
                          Description =
                            "Potassium Sorbate is the very soluble salt of sorbic acid. It is used in many food products as a preservative with an effective pH range up to approximately 5.5 making it useful over a wider range than benzoates. Many dairy products with standards of identity allow the use of potassium sorbate as an optional ingredient, especially to check mold growth in certain kinds of cheese. Commercial use. White powder"
                        },
                        new Product
                        {
                          Id = 46,
                          Category = Categories.First(c => c.Id == 103),
                          Name = "Xanthan Gum",
                          Description =
                            "Xanthan Gum is a stabilizer and thickener for aqueous systems with outstanding characteristics such as temperature, pH and salt stability and pseudoplastic flow behavior It is widely used in the food industry, but also finds numerous technical applications. Commercial use. Green blocks"
                        },
                        new Product
                        {
                          Id = 47,
                          Category = Categories.First(c => c.Id == 103),
                          Name = "Rochelle Salt",
                          Description =
                            "Rochelle Salt is the crystalline mixed sodium/potassium salt of tartaric acid used in medicine as a cathartic, in the preparation of mirrors, as a component of Fehling’s Solution, in metal finishing, in leavening agents, as a buffering agent and as a chelating agent.Sodium Benzoate, the sodium salt of natural benzoic acid, is most suitable for use as an antimicrobial agent in foods and beverages which are naturally in the pH range below 4.5 or can be brought there by addition of a suitable acidulant. Commercial use. White powder"
                        },
                        new Product
                        {
                          Id = 48,
                          Category = Categories.First(c => c.Id == 103),
                          Name = "Fumaric Acid",
                          Description =
                            "Fumaric Acid is non-hygroscopic and guards against moisture pickup and caking. It is used in dry mix beverages, fruit juice drinks, gelatin desserts, pie fillings, refrigerated biscuit doughs, rye bread souring agents, jelling aids, wine, maraschino cherries and other products. Commercial use. Cream gel."
                        },
                        new Product
                        {
                          Id = 48,
                          Category = Categories.First(c => c.Id == 103),
                          Name = "Na4EDTA (Tetrasodium Ethylenediaminetetraacetate)",
                          Description =
                            "Na4EDTA (Tetrasodium Ethylenediaminetetraacetate) is the tetrasodium salt of ethylenediaminetetraacetic acid. Na4EDTA forms water-soluble coordination compounds with multivalent metal ions over a wide pH range. Commercial use. Yellow powder"
                        },

                        new Product
                        {
                          Id = 51,
                          Category = Categories.First(c => c.Id == 103),
                          Name = "Sucrose Esters",
                          Description =
                            "Sucrose esters are used in many applications including bakery, confectionery, cereals, dairy, ice cream and sauces. They are often used in low fat alternatives to maximize the mouth feel provided by fat. Sucrose esters also provide a finer crumb structure and a softer texture in bakery products, stability in dairy or sauces, and improved texture and flavor in mousse and ice cream. Home use. White powder."
                        },
                        new Product
                        {
                          Id = 52,
                          Category = Categories.First(c => c.Id == 103),
                          Name = "Pure-Cote B790",
                          Description =
                            "Pure-Cote® B790 is a low-viscosity, modified corn starch, which forms clear, flexible films without requiring hydration or cooking. Products thickened with Pure-Cote dry into a crispy “glass” at room temperature. It forms clear, flexible films with excellent sheen that are fast-drying and flavor-free. It functions as a strong binder for seasonings on snacks and cereals, and as a smooth, glossy coating agent for confections and baked goods. It can be used to form fruit leather. Home use. White powder."
                        },
                        new Product
                        {
                          Id = 53,
                          Category = Categories.First(c => c.Id == 103),
                          Name = "Sodium Nitrate",
                          Description =
                            "Sodium Nitrate is used in the curing process to prevent botulism poisoning, particularly for long aged meats like country hams.Its commercial use is prohibited by the FDA in smoked and cooked meats, non-smoked and cooked meats, sausages or bacon and is restricted to 200ppm in dry cured uncooked products. Usage for home curing should not exceed 0.1g per 500g of meat. Home use. White powder."
                        },
                        new Product
                        {
                          Id = 54,
                          Category = Categories.First(c => c.Id == 103),
                          Name = "Sodium Caseinate",
                          Description =
                            "Sodium Caseinate aka Casein is a phosphoroprotein commonly found in animal and human milk. Unlike many proteins, casein is not coagulated by heat but by a chemical reaction. It is often used in cheesemaking for clotting. It is also used as a protein helper with transglutaminase to improve the bond of the meat glue. Home use. White powder."
                        },
                        new Product
                        {
                          Id = 55,
                          Category = Categories.First(c => c.Id == 103),
                          Name = "Lambda Carrageenan",
                          Description =
                            "A natural hydrocolloid, carrageenan is a natural extract from specific red seaweed species that are farmed and processed. It is used as a suspending and emulsifying stablizer, thickener, binder and gelling agent. Lambda carrageenan is a cold soluble, non-gelling carrageenan that improves mouthfeel in dairy beverages Home use. White powder."
                        },
                        new Product
                        {
                          Id = 56,
                          Category = Categories.First(c => c.Id == 103),
                          Name = "Food Grade Polysorbate 80",
                          Description =
                            "Polysorbate 80 is a nonionic surfactant and emulsifier derived from polyethoxylated sorbitan and oleic acid, and is often used in foods. It can be used as a foaming agent to make spumas or airs. It is also added as an emulsifier in foods, particularly in ice cream, where polysorbate is added to up to 0.5% (v/v) concentration to make the ice cream smoother and easier to handle, as well as increasing its resistance to melting. Polysorbate prevents milk proteins from completely coating the fat droplets. This allows them to join together in chains and nets, which hold air in the mixture, and provide a firmer texture that holds its shape as the ice cream melts. Home use. Blue liquid."
                        },
                        new Product
                        {
                          Id = 57,
                          Category = Categories.First(c => c.Id == 103),
                          Name = "Slow Set High Methoxyl (HM) Pectin",
                          Description =
                            "Slow Set High Methoxyl Pectin (e440i) is extracted from the peels of citrus fruit. Pectin consists of a complex set of polysaccharides that are present in most primary cell walls of plants. The main use for pectin is as a gelling agent, thickening agent and stabilizer in food. The classical application is giving the jelly-like consistency to jams or marmalades, which would otherwise be sweet juices. Pectin can also be used to stabilize acidic protein drinks, such as drinking yogurt, and as a fat substitute in baked goods. Home use. White powder."
                        },
                        new Product
                        {
                          Id = 58,
                          Category = Categories.First(c => c.Id == 103),
                          Name = "Sodium Citrate",
                          Description =
                            "Sodium Citrate (E331) is the sodium salt of citric acid. Like citric acid, it has a sour taste. Like other salts, it also has a salty taste. It is commonly known as sour salt and is mainly used as a food additive, usually for flavor or as a preservative. It gives club soda both its sour and salty flavors. It reduces the acidity of foods, so it allows spherification with strongly acidic ingredients. Sodium citrate is also used as an antioxidant in food as well as a sequestrant. It dissolves easily and acts instantaneously. Home use. White powder."
                        },
                        new Product
                        {
                          Id = 59,
                          Category = Categories.First(c => c.Id == 103),
                          Name = "Texturas Trisol",
                          Description =
                            "Trisol is a soluble fiber derived from wheat, especially recommended for the preparation of batters for frying and tempura. The result is a texture that remains crunchy for an extended time and prevents the absorption of oil. The recommended usage is 30% Trisol to 70% flour. Home use. Yellow Liquic."
                        },
                        new Product
                        {
                          Id = 50,
                          Category = Categories.First(c => c.Id == 103),
                          Name = "TI Transglutaminase",
                          Description =
                            "Transglutaminase (TG), aka Meat Glue, is a natural enzyme that has the ability to glue protein-containing foods together. When raw meats are bound with TG, they typically have the strength and appearance of whole uncut muscles.  Home use. White powder."
                        },
                        new Product
                        {
                          Id = 50,
                          Category = Categories.First(c => c.Id == 103),
                          Name = "Arabic Gum/Acacia Gum",
                          Description =
                            "Gum arabic, also known as acacia gum is a natural gum made of hardened sap taken from two species of the acacia tree. It a complex mixture of polysaccharides and glycoproteins, is used primarily in the food industry as a stabilizer. It is an important ingredient in soft drink syrups, \"hard\" gummy candies such as gumdrops, marshmallows, M&M's chocolate candies and edible glitter, a very popular, modern cake-decorating staple. Home use. White powder."
                        },
                        new Product
                        {
                          Id = 511,
                          Category = Categories.First(c => c.Id == 103),
                          Name = "Xanthan Gum",
                          Description =
                            "Xanthan Gum is a long chain polysacharide composed of the sugars glucose, mannose, and glucuronic acid. It is used as a thickener in sauces, as an agent in ice cream that prevents ice crystals from forming, and as a fat substitute that adds the \"mouth feel\" of fat without the calories. Home use. White powder."
                        }
                      };

        return _products;
      }
    }

    public static MethodInfo GetOrderByMethod(SortItem sortItem)
    {
      var methodName = sortItem.SortDirection == ListSortDirection.Ascending ? "OrderBy" : "OrderByDescending";
      var orderByMethodInfo = typeof(Queryable)
        .GetMethods(BindingFlags.Public | BindingFlags.Static)
        .Single(mi => mi.Name == methodName
                      && mi.IsGenericMethodDefinition
                      && mi.GetGenericArguments().Length == 2
                      && mi.GetParameters().Length == 2);

      return orderByMethodInfo;
    }
  }
}