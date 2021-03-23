export interface Answer<T> {
    value: T;
    success: boolean;
    errors: Array<string>;
    message: string;
    exceptionMessage: string;
}
