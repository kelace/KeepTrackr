import React from 'react';
import './Clendar.css'
import { useDispatch, useSelector } from 'react-redux';
import Calendar from 'react-calendar';
import { changeCompletionDate } from '../tasksPageSlice';
import { AppDispatch } from '../../../../app/store';
import 'react-calendar/dist/Calendar.css';

function CalendarModal() {

    const dispatch = useDispatch<AppDispatch>();

    const cardId = useSelector((x: any) => x.tasks.openedCardId);

    return (
        <div className="calendar_wrapper">
            <Calendar onChange={(x: any) => dispatch(changeCompletionDate({ cardId, completionDate: x }))} value={new Date()} />
      </div>
  );
}

export default CalendarModal;