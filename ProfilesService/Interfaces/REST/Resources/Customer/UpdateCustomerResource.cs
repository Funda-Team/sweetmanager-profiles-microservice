﻿using ProfilesService.Domain.Model.ValueObject;

namespace ProfilesService.Interfaces.REST.Resources.Customer;

public record UpdateCustomerResource(string Email, int Phone, StateType State, int HotelId);