export type ApiToken = {
    sub: number;
    cid: number;
    email: string;
    country: string;
    givenname: string;
    surname: string;
    rating: string;
    ratingInt: number;
    division: string;
    scp: string;
    roles: string[];
    exp: number;
    iss: string;
    aud: string;
}

export type User = {
    cid: number;
    email: string;
    firstName: string;
    lastName: string;
    rating: string;
    ratingInt: number;
    division: string;
    permissions: string[];
}