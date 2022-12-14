export const baseUrl = 'https://localhost:7243' + '/api';

export const authenticationServiceUrl = baseUrl + '/Authentication/';
export const loginUrl = authenticationServiceUrl + 'login';
export const registerUrl = authenticationServiceUrl + 'registration';
export const logoutUrl = authenticationServiceUrl + 'logout';
export const refreshTokenUrl = authenticationServiceUrl + 'refresh-token';

export const adminUrl = '/admin/'
export const adminUsersUrl = baseUrl + adminUrl + 'users/';
export const adminBookingsUrl = baseUrl + adminUrl + 'bookings/';

export const homeUrl = '/home/'
export const reservedBookingListUrl = baseUrl + homeUrl + 'bookings/reserved';
export const unReservedBookingListUrl = baseUrl + homeUrl + 'bookings/unreserved';
export const bookingInfoUrl = baseUrl + homeUrl + 'bookings/';

export const addCommentUrl = baseUrl + homeUrl + 'comments';

export const managerUrl = '/manager/';
export const subscribeUserUrl = baseUrl + managerUrl + 'subscribe';

export const developerUrl = '/developer/';
export const isDeveloperHasReservationUrl = baseUrl + developerUrl + 'is-reservation/';
export const isItUserBookingUrl = baseUrl + developerUrl + 'is-it-user-reservation/';
export const changeBookingDateUrl = baseUrl + developerUrl + 'change-booking-date/';

export const userUrl = '/user/';
export const getUserProfileInfoUrl = baseUrl + userUrl + 'info';
export const editUserPasswordUrl = baseUrl + userUrl + 'password';
export const editUserPersonalInfodUrl = baseUrl + userUrl + 'info';
