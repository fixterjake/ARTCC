import { Faq } from "@/models/Faq";
import { Disclosure, Transition } from "@headlessui/react";
import Head from "next/head";
import { Fragment } from "react";

type FaqProps = {
    faqs: Faq[];
};

export default function FaqPage({ faqs }: FaqProps) {
    return (
        <>
            <Head>
                <title>FAQ :: ARTCC</title>
                <meta name="description" content="Home :: ARTCC" />
                <meta name="viewport" content="width=device-width, initial-scale=1" />
                <link rel="icon" href="/favicon.ico" />
            </Head>
            <div className="flex mt-12">
                <div className="w-full min-h-[4rem] bg-gray-800 rounded-md shadow-md">
                    <div className="h-full mt-8 text-white">
                        <h2 className="text-2xl font-bold text-center">Frequently Asked Questions</h2>
                        <div className="m-8 border-t-2 border-white"></div>
                        <div className="my-8">
                            {faqs.map((faq) => (
                                <div key={faq.id} className="max-w-[60%] ml-[20%]">
                                    <Disclosure>
                                        <div className="mb-24">
                                            <Disclosure.Button className="w-full py-4 pl-[15%] text-xl font-bold bg-gray-500 rounded-md text-start">
                                                <div className="grid grid-cols-4 gap-4">
                                                    <div className="col-span-3">{faq.question}</div>
                                                    <div className="col-span-1">
                                                        <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="w-6 h-6">
                                                            <path strokeLinecap="round" strokeLinejoin="round" d="M19.5 5.25l-7.5 7.5-7.5-7.5m15 6l-7.5 7.5-7.5-7.5" />
                                                        </svg>
                                                    </div>
                                                </div>
                                            </Disclosure.Button>
                                            <Transition
                                                as={Fragment}
                                                enter="transition ease-out duration-100"
                                                enterFrom="transform opacity-0 scale-95"
                                                enterTo="transform opacity-100 scale-100"
                                                leave="transition ease-in duration-200"
                                                leaveFrom="transform opacity-100 scale-100"
                                                leaveTo="transform opacity-0 scale-95"
                                            >
                                                <Disclosure.Panel className="fixed w-full max-w-[48%] py-4 mt-4 text-lg font-medium bg-gray-400 rounded-md">
                                                    {faq.answer}
                                                </Disclosure.Panel>
                                            </Transition>
                                        </div>
                                    </Disclosure>
                                </div>
                            ))}
                        </div>
                    </div>
                </div>
            </div>
        </>
    );
}

export async function getServerSideProps() {
    const res = await fetch(`${process.env.NEXT_PUBLIC_API_URL}/faq/all`);
    const response = await res.json();
    return {
        props: {
            faqs: response.data
        }
    };
}