import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export function emailValidator(control: AbstractControl): ValidationErrors | null {
    const value = (control.value as string);
    if (!value) { return null; }
    const isValidEmail = /^[a-zA-Z0-9\.-]{6,}@\w+\.(com|bg)$/.test(value);
    return isValidEmail ? null : { emailValidator: true };
}

export function rePasswordValidatorFactory(targetControl: AbstractControl): ValidatorFn {
    return function rePasswordValidator(control: AbstractControl): ValidationErrors | null {
        const areTheSame = targetControl.value === control.value;
        return areTheSame ? null : { rePasswordValidator: true };
    };
}

export function emailValidatorBackend(email: string): boolean {
    return /^[a-zA-Z0-9\.-]{6,}@\w+\.(com|bg)$/.test(email);
}

export function titleValidator(title: string): boolean {
    return /^[А-Я][а-я]{6,}\w+$/.test(title);
}