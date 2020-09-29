using System.Collections.Generic;
using TrickyBookStore.Models;

namespace TrickyBookStore.Services.Store
{
    public static class Subscriptions
    {
        public static readonly IEnumerable<Subscription> Data = new List<Subscription>
        {
            new Subscription { Id = 1, SubscriptionType = SubscriptionTypes.Free, Priority = 1,
                PriceDetails = new Dictionary<string, double>
                {
                    { "FixPrice", 0 },
                    { "OldBookDiscount", 10 },
                    { "NewBookDiscount", 0 },
                    { "NewBookDiscountAmmount", 0 }
                }
            },
            new Subscription { Id = 2, SubscriptionType = SubscriptionTypes.Paid, Priority = 2,
                PriceDetails = new Dictionary<string, double>
                {
                    { "FixPrice", 50 },
                    { "OldBookDiscount", 95 },
                    { "NewBookDiscount", 5 },
                    { "NewBookDiscountAmmount", 3 }
                }
            },
            new Subscription { Id = 3, SubscriptionType = SubscriptionTypes.Premium, Priority = 3,
                PriceDetails = new Dictionary<string, double>
                {
                    { "FixPrice", 200 },
                    { "OldBookDiscount", 100 },
                    { "NewBookDiscount", 15 },
                    { "NewBookDiscountAmmount", 3 }
                }
            },
            new Subscription { Id = 4, SubscriptionType = SubscriptionTypes.CategoryAddicted, Priority = 0,
                PriceDetails = new Dictionary<string, double>
                {
                    { "FixPrice", 75 },
                    { "OldBookDiscount", 100 },
                    { "NewBookDiscount", 15 },
                    { "NewBookDiscountAmmount", 3 }
                },
                BookCategoryId = 1
            },
            new Subscription { Id = 5, SubscriptionType = SubscriptionTypes.CategoryAddicted, Priority = 0,
                PriceDetails = new Dictionary<string, double>
                {
                    { "FixPrice", 75 },
                    { "OldBookDiscount", 100 },
                    { "NewBookDiscount", 15 },
                    { "NewBookDiscountAmmount", 3 }

                },
                BookCategoryId = 2
            },
            new Subscription { Id = 6, SubscriptionType = SubscriptionTypes.CategoryAddicted, Priority = 0,
                PriceDetails = new Dictionary<string, double>
                {
                    { "FixPrice", 75 },
                    { "OldBookDiscount", 100 },
                    { "NewBookDiscount", 15 },
                    { "NewBookDiscountAmmount", 3 }

                },
                BookCategoryId = 3
            },
            new Subscription { Id = 7, SubscriptionType = SubscriptionTypes.CategoryAddicted, Priority = 0,
                PriceDetails = new Dictionary<string, double>
                {
                    { "FixPrice", 75 },
                    { "OldBookDiscount", 100 },
                    { "NewBookDiscount", 15 },
                    { "NewBookDiscountAmmount", 3 }

                },
                BookCategoryId = 4
            }

        };
    }
}
