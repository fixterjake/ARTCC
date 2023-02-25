import Head from "next/head";

export default function Home() {
    return (
        <>
            <Head>
                <title>Home :: ARTCC</title>
                <meta name="description" content="Home :: ARTCC" />
                <meta name="viewport" content="width=device-width, initial-scale=1" />
                <link rel="icon" href="/favicon.ico" />
            </Head>
            <div className="mt-24">
                <h1 className="text-4xl font-bold">Home</h1>
            </div>
        </>
    );
}
