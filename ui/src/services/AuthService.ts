import { ApiToken } from "@/models/Auth";

export async function sendCodeCallback(code: string): Promise<Response> {
    return await fetch(`${process.env.NEXT_PUBLIC_API_URL}/Auth/login/callback`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({"authorization_code": code}),
    });
}

export async function sendLogout(): Promise<void> {
    await fetch(`${process.env.NEXT_PUBLIC_API_URL}/Auth/logout`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            "Authorization": `Bearer ${getToken()}`
        }
    });
}

function parseJwt(token: string): ApiToken | undefined {
    if (!token)
        return;
    const base64Url = token.split(".")[1];
    if (!base64Url)
        return;
    const base64 = base64Url.replace("-", "+").replace("_", "/");
    return JSON.parse(window.atob(base64));
}

export function getToken(): string | null {
    return localStorage.getItem("accessToken");
}

export function isLoggedIn(): boolean {
    const token = getToken();
    return !!token;
}

export function getCid(): number | null {
    const token = getToken();
    if (!token)
        return null;
    const parsed = parseJwt(token);
    if (!parsed)
        return null;
    return parsed.cid;
}

export function getEmail(): string | null {
    const token = getToken();
    if (!token)
        return null;
    const parsed = parseJwt(token);
    if (!parsed)
        return null;
    return parsed.email;
}

export function getFirstName(): string | null {
    const token = getToken();
    if (!token)
        return null;
    const parsed = parseJwt(token);
    if (!parsed)
        return null;
    return parsed.givenname;
}

export function getLastName(): string | null {
    const token = getToken();
    if (!token)
        return null;
    const parsed = parseJwt(token);
    if (!parsed)
        return null;
    return parsed.surname;
}

export function getFullName(): string | null {
    const token = getToken();
    if (!token)
        return null;
    const parsed = parseJwt(token);
    if (!parsed)
        return null;
    return `${parsed.givenname} ${parsed.surname}`;
}

export function getRating(): string | null {
    const token = getToken();
    if (!token)
        return null;
    const parsed = parseJwt(token);
    if (!parsed)
        return null;
    return parsed.rating;
}

export function getRatingInt(): number | null {
    const token = getToken();
    if (!token)
        return null;
    const parsed = parseJwt(token);
    if (!parsed)
        return null;
    return parsed.ratingInt;
}

export function getDivision(): string | null {
    const token = getToken();
    if (!token)
        return null;
    const parsed = parseJwt(token);
    if (!parsed)
        return null;
    return parsed.division;
}

export function getPermissions(): string[] | null {
    const token = getToken();
    if (!token)
        return null;
    const parsed = parseJwt(token);
    if (!parsed)
        return null;
    return parsed.roles.sort();
}