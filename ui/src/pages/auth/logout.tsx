import { useAuthContext } from "@/contexts/AuthContext";
import { deleteToken, sendLogout } from "@/services/AuthService";
import { useRouter } from "next/router";
import { useEffect } from "react";

export default function AuthLogout() {

    const [loggedIn, setLoggedIn] = useAuthContext();

    const router = useRouter();

    useEffect(() => {
        if (loggedIn)
            sendLogout().then(() => {
                setLoggedIn(false);
                deleteToken();
                router.push("/");
            });
    }, [loggedIn, setLoggedIn, router]);

    return (
        <>
            <div className="mx-[10%]">
                <h1 className="text-3xl font-bold underline">Loading...</h1>
            </div>
        </>
    );
}