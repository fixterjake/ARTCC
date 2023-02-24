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