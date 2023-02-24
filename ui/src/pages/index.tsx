import { getPermissions } from "@/services/AuthService";
import Head from "next/head";
import { useEffect, useState } from "react";

export default function Home() {

    const [permissions, setPermissions] = useState<string[]>([]);

    useEffect(() => {
        setPermissions(getPermissions() || []);
    }, []);

    return (
        <>
            <Head>
                <title>Home :: ARTCC</title>
                <meta name="description" content="Home :: ARTCC" />
                <meta name="viewport" content="width=device-width, initial-scale=1" />
                <link rel="icon" href="/favicon.ico" />
            </Head>
            <div className="mt-24">
                <ul>
                    {permissions?.map((permission, index) => (
                        <li key={index}>{permission}</li>
                    ))}
                </ul>
            </div>
        </>
    );
}
