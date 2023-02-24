import { sendCodeCallback } from "@/services/AuthService";
import { NextPageContext } from "next";
import { useRouter } from "next/router";
import { useEffect } from "react";

type AuthCallbackProps = {
    accessToken: string;
}

export default function AuthCallback({ accessToken }: AuthCallbackProps) {

    const router = useRouter();

    useEffect(() => {
        localStorage.setItem("accessToken", accessToken);
        router.push("/");
    }, [accessToken, router]);

    return (
        <>
            <div className="mx-[10%]">
                <h1 className="text-3xl font-bold underline">Loading...</h1>
            </div>
        </>
    );
}

export async function getServerSideProps(ctx: NextPageContext) {
    const res = await sendCodeCallback(ctx.query.code as string);
    if (!res.ok) return {props: {}};
    const data = await res.json();
    return {
        props: {
            accessToken: JSON.stringify(data.apiToken.accessToken).replaceAll("\"", "")
        }
    };
}
